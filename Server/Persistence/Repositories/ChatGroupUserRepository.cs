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
    public class ChatGroupUserRepository: BaseRepository, IChatGroupUserRepository
    {
        public ChatGroupUserRepository(AppDbContext context) : base(context){ }

        public async Task<ChatGroupUser> GetByUuidAsync(Guid uuid)
        {
            try
            {
                return await _context
                    .ChatGroupUsers
                    .Where(chatGroupUser => chatGroupUser.Uuid.Equals(uuid)).SingleAsync();
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetUsersFromChatGroup(long chatGroupId)
        {
            try
            {
                IEnumerable<User> users = await _context.ChatGroupUsers
                    .Where(cgu => cgu.ChatGroupId == chatGroupId)
                    .Select(cgu => cgu.User).ToListAsync();
                return users;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }

        }
    }
}
