using LyteChat.Server.Data.Models;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.ServiceInterface
{
    public interface IChatGroupUserService : IServiceBase<ChatGroupUser>
    {
        public Task<ChatGroupUser> GetByUserAndChatGroupAsync(Guid userUuid, Guid chatGroupUuid);

        public Task<IEnumerable<UserDTO>> GetUsersForChatGroupAsync(Guid chatGroupUuid);

        public Task<IEnumerable<ChatGroupDTO>> GetChatGroupsForUserAsync(Guid UserUuid);

        public Task<ChatGroupUserResponse> AddUserToChatGroupAsync(ChatGroupUserDTO chatGroupUser);

        public Task<ChatGroupUserResponse> RemoveUserFromChatGroupAsync(Guid userUuid, Guid chatGroupUuid);
    }
}
