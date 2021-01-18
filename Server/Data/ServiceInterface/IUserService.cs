using LyteChat.Shared.DataTransferObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.ServiceInterface
{
    public interface IUserService : IServiceBase<UserDTO>
    {
        public Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        public Task<UserDTO> GetAnonymousUserAsync();
    }
}
