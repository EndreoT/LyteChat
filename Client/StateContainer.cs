using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Threading.Tasks;


namespace LyteChat.Client
{
    public class StateContainer : IAsyncDisposable
    {
        public UserDTO CurrentUser;

        public Dictionary<Guid, UserDTO> AllUsers = new Dictionary<Guid, UserDTO>();

        public Dictionary<Guid, ChatGroupData> ChatGroupsForUser = new Dictionary<Guid, ChatGroupData>();

        public event Action OnChange;

        private readonly HttpClient Http;

        private HubConnection hubConnection;

        private string accessToken;

        public StateContainer(HttpClient http)
        {
            Http = http;
        }

        public async Task Init(Uri url)
        {
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

            // Login as anonymous user first
            var loginResMessage = await Http.PostAsync("/api/authenticate/login/anonymous", null);
            LoginResponse loginRes = await loginResMessage.Content.ReadFromJsonAsync<LoginResponse>();
            accessToken = loginRes.Token;

            try
            {
                await hubConnection.StartAsync();
            }
            catch (WebSocketException e)
            {
                Console.WriteLine(e);
            }

            IEnumerable<UserDTO> users = await Http.GetFromJsonAsync<List<UserDTO>>("/api/User");
            AllUsers = users.ToDictionary(u => u.Uuid);

            CurrentUser = AllUsers.FirstOrDefault().Value;

            await GetChatGroupUsersAndMessages();
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
            await GetChatGroupUsersAndMessages();
            NotifyStateChanged();
        }

        public async Task GetChatGroupUsersAndMessages()
        {
            //Clear all chat groups
            ChatGroupsForUser = new Dictionary<Guid, ChatGroupData>();

            //Get all chat groups for the user
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
            ChatGroupsForUser[chatGroupUuid].Users = users.Select(u => u.Uuid).ToList();
        }

        private async Task AddMessagesForChatGroupAsync(Guid chatGroupUuid)
        {
            IEnumerable<ChatMessageDTO> messages = await Http.GetFromJsonAsync<ChatMessageDTO[]>(
                $"/api/ChatGroup/{chatGroupUuid}/message");
            ChatGroupsForUser[chatGroupUuid].Messages = messages.ToList();
        }

        public async Task<bool> ModifyGroupMembership(bool joinGroup, Guid chatGroupUuid)
        {
            ChatGroupUserDTO body = new ChatGroupUserDTO { UserUuid = CurrentUser.Uuid, ChatGroupUuid = chatGroupUuid };
            HttpResponseMessage response;
            if (joinGroup)
            {
                response = await Http.PostAsJsonAsync(
                    $"/api/chatGroupUser", body);
            }
            else
            {
                response = await Http.DeleteAsync(
                    $"/api/chatGroupUser/user/{CurrentUser.Uuid}/chatgroup/{chatGroupUuid}");
            }

            ChatGroupUserResponse content = await response.Content.ReadFromJsonAsync<ChatGroupUserResponse>();
            if (content.Success == true)
            {
                await GetChatGroupUsersAndMessages();
                return true;
            }
            else
            {
                //TODO handle issue with server
                return false;
            }
        }

        public async Task<List<ChatGroupDTO>> GetChatGroups()
        {
            return await Http.GetFromJsonAsync<List<ChatGroupDTO>>("api/ChatGroup");
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        public string ConnectionState()
        {
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
            await hubConnection.DisposeAsync();
        }
    }
}
