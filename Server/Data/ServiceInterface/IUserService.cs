using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Shared.DataTransferObject;

namespace LyteChat.Server.Data.ServiceInterface
{
    public interface IUserService: IServiceBase<UserDTO>
    {
        public Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        public Task<UserDTO> GetAnonymousUserAsync();
    }
}
