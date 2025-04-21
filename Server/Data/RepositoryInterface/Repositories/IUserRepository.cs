using LyteChat.Server.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.RepositoryInterface.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User?> GetAnonymousUserAsync();
    }
}
