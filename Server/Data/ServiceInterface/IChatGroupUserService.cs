using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Server.Data.Models;
using LyteChat.Shared.DataTransferObject;
using LyteChat.Shared.Communication;

namespace LyteChat.Server.Data.ServiceInterface
{
    public interface IChatGroupUserService: IServiceBase<ChatGroupUser>
    {
        public Task<IEnumerable<UserDTO>> GetUsersForChatGroupAsync(Guid chatGroupUuid);

        public Task<IEnumerable<ChatGroupDTO>> GetChatGroupsForUserAsync(Guid UserUuid);

        public Task<ChatGroupUserResponse> AddUserToChatGroupAsync(ChatGroupUserDTO chatGroupUser);

        public Task<ChatGroupUserResponse> RemoveUserFromChatGroupAsync(Guid userUuid, Guid chatGroupUuid);
    }
}
