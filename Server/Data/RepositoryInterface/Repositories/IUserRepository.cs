using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Server.Data.Models;

namespace LyteChat.Server.Data.RepositoryInterface.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User> GetAnonymousUserAsync();
    }
}
