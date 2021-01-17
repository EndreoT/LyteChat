using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text.Json;


namespace LyteChat.Client
{
    public class StateContainer : IAsyncDisposable
    {
        public UserDTO CurrentUser;

        public Dictionary<Guid, UserDTO> KnownUsers = new Dictionary<Guid, UserDTO>();

        public Dictionary<Guid, ChatGroupData> ChatGroupsForUser = new Dictionary<Guid, ChatGroupData>();

        public List<ChatGroupDTO> AllChatGroups = new List<ChatGroupDTO>();

        public event Action OnChange;

        private readonly HttpClient Http;

        private HubConnection hubConnection;

        private readonly JWTAuthenticationStateProvider _authService;

        public StateContainer(HttpClient http, JWTAuthenticationStateProvider authService)
        {
            Http = http;
            _authService = authService;
        }

        public async Task Init(Uri url)
        {
            string accessToken = await _authService.GetTokenAsync();
            if (accessToken == null)
            {
                return;
            }
            
            hubConnection = new HubConnectionBuilder()
                .WithUrl(url, options =>
                {
                    options.SkipNegotiation = true;
                    options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                    options.AccessTokenProvider = () => Task.FromResult(accessToken);
                })
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On("ReceiveMessage", (ChatMessageResponse chatMessageRes) =>
            {
                if (!chatMessageRes.Success)
                {
                //TODO
                Console.WriteLine(chatMessageRes.ErrorMessage);
                }
                else
                {
                    ChatMessageDTO chatMessage = chatMessageRes.ChatMessageDTO;
                    if (chatMessage != null && ChatGroupsForUser.ContainsKey(chatMessage.ChatGroupUuid))
                    {
                        ChatGroupsForUser[chatMessage.ChatGroupUuid].Messages.Add(chatMessage);
                        NotifyStateChanged();
                    }
                }
            });

            hubConnection.Closed += async (error) =>
            {
                Console.WriteLine(error);
            };

            //hubConnection.On<string>("WelcomeMessage", (string welcomeChat) =>
            //{
            //    messages.Add(welcomeChat);
            //    StateHasChanged();
            //});

            try
            {
                await hubConnection.StartAsync();
            }
            catch (WebSocketException e)
            {
                Console.WriteLine(e);
            }

            var authState = await _authService.GetAuthenticationStateAsync();
            string userUuid = authState.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string userName = authState.User.FindFirst(ClaimTypes.Name).Value;

            bool parseSuccess = Guid.TryParse(userUuid, out Guid guid);
            if (parseSuccess)
            {
                UserDTO currentUser = new UserDTO { Uuid = guid, Name = userName };
                
                await SetUser(currentUser);
            }
            else
            {
                //TODO
            }
        }

        public async Task SendMessage(ChatMessageDTO chatMessage)
        {
            try
            {
                await hubConnection.InvokeAsync("CreateMessage", chatMessage);
            }
            catch (WebSocketException e)
            {
                Console.WriteLine(e);
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }
            catch (HubException e)
            {
                // Probably unauthorized
                Console.WriteLine(e);
            }
        }

        public async Task SetUser(UserDTO currentUser)
        {
            CurrentUser = currentUser;

            // Set Bearer token header for all future requests
            string authToken = await _authService.GetTokenAsync();
            AuthenticationHeaderValue header = new AuthenticationHeaderValue("Bearer", authToken);
            Http.DefaultRequestHeaders.Authorization = header;

            AllChatGroups = await GetChatGroups();
            
            await GetChatGroupUsersAndMessages();
            NotifyStateChanged();
        }

        public async Task RemoveStateOnLogout()
        {
            KnownUsers = new Dictionary<Guid, UserDTO>();
            ChatGroupsForUser = new Dictionary<Guid, ChatGroupData>();
            // Remove Bearer token header
            Http.DefaultRequestHeaders.Authorization = null;

            await DisposeAsync();
            NotifyStateChanged();
        }

        public async Task GetChatGroupUsersAndMessages()
        {
            //Clear all chat groups
            ChatGroupsForUser = new Dictionary<Guid, ChatGroupData>();

            //Get chat groups the user belongs to
            List<ChatGroupDTO> chatGroups = await Http.GetFromJsonAsync<List<ChatGroupDTO>>(
            $"/api/user/{CurrentUser.Uuid}/chatgroup");

            foreach (ChatGroupDTO chatGroup in chatGroups)
            {
                ChatGroupsForUser[chatGroup.Uuid] = new ChatGroupData(chatGroup);
            }
            //Get the users and messages for each chat group
            List<Task> tasks = new List<Task>();
            foreach (Guid chatGroupGuid in ChatGroupsForUser.Keys)
            {
                tasks.Add(AddMessagesForChatGroupAsync(chatGroupGuid));
                tasks.Add(GetUsersForChatGroupAsync(chatGroupGuid));
            }
            await Task.WhenAll(tasks);
            NotifyStateChanged();
        }

        private async Task GetUsersForChatGroupAsync(Guid chatGroupUuid)
        {
            IEnumerable<UserDTO> users = await Http.GetFromJsonAsync<UserDTO[]>($"/api/ChatGroup/{chatGroupUuid}/user");
            List<Guid> chatGroupUserUuids = new List<Guid>();
            foreach (UserDTO user in users)
            {
                chatGroupUserUuids.Add(user.Uuid);
                if (!KnownUsers.ContainsKey(user.Uuid))
                {
                    KnownUsers[user.Uuid] = user;
                }
            }
            ChatGroupsForUser[chatGroupUuid].Users = chatGroupUserUuids;
        }

        private async Task AddMessagesForChatGroupAsync(Guid chatGroupUuid)
        {
            IEnumerable<ChatMessageDTO> messages = await Http.GetFromJsonAsync<ChatMessageDTO[]>(
                $"/api/ChatGroup/{chatGroupUuid}/message");
            ChatGroupsForUser[chatGroupUuid].Messages = messages.ToList();
        }

        public async Task<bool> ModifyGroupMembership(bool joinGroup, Guid chatGroupUuid)
        {
            ChatGroupUserDTO body = new ChatGroupUserDTO { ChatGroupUuid = chatGroupUuid };
            HttpResponseMessage response;

            if (joinGroup)
            {
                response = await Http.PostAsJsonAsync(
                    $"/api/chatGroupUser", body);
            }
            else
            {
                response = await Http.DeleteAsync(
                    $"/api/chatGroupUser/{chatGroupUuid}");
            }
            try
            {
                ChatGroupUserResponse content = await response.Content.ReadFromJsonAsync<ChatGroupUserResponse>();
                if (content.Success == true)
                {
                    await GetChatGroupUsersAndMessages();
                    NotifyStateChanged();
                    return true;
                }
                else
                {
                    //TODO handle issue with server
                }
            } catch (JsonException e)
            {
                // TODO probably unauthorized
                Console.WriteLine(e);
            }
            return false;
        }

        public async Task<List<ChatGroupDTO>> GetChatGroups()
        {
            return await Http.GetFromJsonAsync<List<ChatGroupDTO>>("api/ChatGroup");
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;

        public string ConnectionState()
        {
            if (hubConnection == null)
            {
                return "Disconnected";
            }
            string connectionState = hubConnection.State switch
            {
                HubConnectionState.Connected => "Connected",
                HubConnectionState.Disconnected => "Disconnected",
                HubConnectionState.Connecting => "Connecting",
                HubConnectionState.Reconnecting => "Reconnecting",
                _ => "",
            };

            return connectionState;
        }

        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null)
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}
