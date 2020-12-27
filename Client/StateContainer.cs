using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using LearnBlazor.Shared.DataTransferObject;
using LearnBlazor.Shared.Communication;


namespace LearnBlazor.Client
{
    public class StateContainer: IAsyncDisposable
    {
        public UserDTO CurrentUser;

        public Dictionary<Guid, UserDTO> AllUsers = new Dictionary<Guid, UserDTO>();

        public Dictionary<Guid, ChatGroupData> ChatGroupsForUser = new Dictionary<Guid, ChatGroupData>();

        public event Action OnChange;

        private readonly HttpClient Http;

        internal HubConnection hubConnection;
        private NavigationManager NavigationManager { get; set; }

        public StateContainer(HttpClient http, NavigationManager navigationManager)
        {
            Http = http;
            NavigationManager = navigationManager;
        }

        public async Task Init(Uri url)
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(url)
                //.WithAutomaticReconnect()
                .Build();

            hubConnection.On<ChatMessageResponse>("ReceiveMessage", (ChatMessageResponse chatMessageRes) =>
            {
                if (!chatMessageRes.Success)
                {
                    //TODO
                    Console.WriteLine(chatMessageRes.ErrorMessage);
                }
                else
                {
                    ChatMessageDTO chatMessage = chatMessageRes.ChatMessageDTO;
                    if (chatMessage != null)
                    {
                        ChatGroupsForUser[chatMessage.ChatGroupUuid].Messages.Add(chatMessage);
                        NotifyStateChanged();
                    }
                }
            });

            //hubConnection.On<string>("WelcomeMessage", (string welcomeChat) =>
            //{
            //    messages.Add(welcomeChat);
            //    StateHasChanged();
            //});

            await hubConnection.StartAsync();
            IEnumerable<UserDTO> users = await Http.GetFromJsonAsync<List<UserDTO>>("/api/User");
            AllUsers = users.ToDictionary(u => u.Uuid);

            CurrentUser = AllUsers.FirstOrDefault().Value;

            await GetChatGroupUsersAndMessages();
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

        public async Task <bool> ModifyGroupMembership(bool joinGroup, Guid chatGroupUuid)
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

        public bool IsConnected =>
            hubConnection.State == HubConnectionState.Connected;

        public async ValueTask DisposeAsync()
        {
            await hubConnection.DisposeAsync();
        }
    }
}
