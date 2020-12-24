using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using LearnBlazor.Shared.DataTransferObject;


namespace LearnBlazor.Client
{
    public class StateContainer
    {
        public UserDTO CurrentUser;

        public Dictionary<Guid, UserDTO> AllUsers = new Dictionary<Guid, UserDTO>();

        public Dictionary<Guid, ChatGroupData> ChatGroupsForUser = new Dictionary<Guid, ChatGroupData>();

        public event Action OnChange;

        private readonly HttpClient Http;

        public StateContainer(HttpClient http)
        {
            Http = http;
        }

        public async Task Init()
        {
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

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
