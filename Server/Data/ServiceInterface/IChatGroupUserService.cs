using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Shared.DataTransferObject;
using LearnBlazor.Shared.Communication;

namespace LearnBlazor.Server.Data.ServiceInterface
{
    public interface IChatGroupUserService: IServiceBase<ChatGroupUser>
    {
        public Task<IEnumerable<UserDTO>> GetUsersForChatGroupAsync(Guid chatGroupUuid);

        public Task<IEnumerable<ChatGroupDTO>> GetChatGroupsForUserAsync(Guid UserUuid);

        public Task<ChatGroupUserResponse> AddUserToChatGroupAsync(ChatGroupUserDTO chatGroupUser);

        public Task<ChatGroupUserResponse> RemoveUserFromChatGroupAsync(Guid userUuid, Guid chatGroupUuid);
    }
}
