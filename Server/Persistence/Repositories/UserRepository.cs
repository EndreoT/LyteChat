using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LearnBlazor.Server.Persistence.Context;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Server.Data.RepositoryInterface.Repositories;

namespace LearnBlazor.Server.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User> GetAnonymousUserAsync()
        {
            try
            {
                return await _context.Users
                    .Where(user => user.Name.Equals("Anonymous"))
                    .SingleAsync();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
