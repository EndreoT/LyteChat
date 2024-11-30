using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.RepositoryInterface.Repositories;
using LyteChat.Server.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyteChat.Server.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (InvalidOperationException)
            {
                return Array.Empty<User>();
            }
        }

        public async Task<User> GetAnonymousUserAsync()
        {
            try
            {
                return await _context.Users
                    .Where(user => user.UserName.Equals("Anonymous"))
                    .SingleAsync();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public async Task<User> GetByUuidAsync(Guid uuid)
        {
            try
            {
                return await _context
                    .Users
                    .Where(user => user.Id.Equals(uuid)).SingleAsync();

            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
