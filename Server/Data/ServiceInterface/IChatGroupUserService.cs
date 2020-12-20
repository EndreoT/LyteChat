using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Shared.DataTransferObject;

namespace LearnBlazor.Server.Data.ServiceInterface
{
    public interface IChatGroupUserService: IServiceBase<ChatGroupUser>
    {
        public Task<IEnumerable<UserDTO>> GetUsersFromChatGroup(Guid chatGroupUuId);
    }
}
