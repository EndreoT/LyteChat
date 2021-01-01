using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Server.Data.Models;

namespace LyteChat.Server.Data.RepositoryInterface.Repositories
{
    public interface IChatGroupUserRepository: IBaseRepository<ChatGroupUser>
    {
        public Task<IEnumerable<User>> GetUsersFromChatGroup(long chatGroupId);

        public Task<IEnumerable<ChatGroup>> GetChatGroupsForUser(Guid UserId);

        public Task AddUserToChatGroupAsync(ChatGroupUser chatGroupUser);

        public Task<ChatGroupUser> GetByUserAndChatGroupAsync(Guid userId, long ChatGroupId);

        public Task<ChatGroupUser> GetByUserAndChatGroupAsync(Guid userId, Guid chatGroupUuid);

        public void RemoveUserFromChatGroup(ChatGroupUser chatGroupUser);
    }
}
