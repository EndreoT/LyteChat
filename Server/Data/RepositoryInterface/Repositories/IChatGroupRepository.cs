using LyteChat.Server.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.RepositoryInterface.Repositories
{
    public interface IChatGroupRepository : IBaseRepository<ChatGroup>
    {
        public Task<IEnumerable<ChatGroup>> ListChatGroupsAsync();

        public Task<ChatGroup?> GetAllChatAsync();

        public Task<ChatGroup?> FindByName(string chatGroupName);

        public Task AddChatGroupAsync(ChatGroup chatGroup);
    }
}
