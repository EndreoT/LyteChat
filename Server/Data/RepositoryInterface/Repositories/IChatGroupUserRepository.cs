using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.Models;

namespace LearnBlazor.Server.Data.RepositoryInterface.Repositories
{
    public interface IChatGroupUserRepository: IBaseRepository<ChatGroupUser>
    {
        public Task<IEnumerable<User>> GetUsersFromChatGroup(long chatGroupId);

        public Task<IEnumerable<ChatGroup>> GetChatGroupsForUser(long UserId);

        public Task AddUserToChatGroupAsync(ChatGroupUser chatGroupUser);

        public Task<ChatGroupUser> GetByUserAndChatGroupAsync(long userId, long ChatGroupId);

        public Task<ChatGroupUser> GetByUserAndChatGroupAsync(Guid userUuid, Guid chatGroupUuid);

        public Task RemoveUserFromChatGroupAsync(ChatGroupUser chatGroupUser);
    }
}
