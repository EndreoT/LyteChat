using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Persistence.Context;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Server.Data.RepositoryInterface.Repositories;

namespace LearnBlazor.Server.Persistence.Repositories
{
    public class ChatGroupRepository : BaseRepository, IChatGroupRepository
    {

        public ChatGroupRepository(AppDbContext context) : base(context) { }
        public async Task<ChatGroup> GetByUUIdAsync(Guid uuid)
        {
            try
            {
                return await _context.ChatGroups
                   .Where(chatGroup => chatGroup.Uuid == uuid)
                   .SingleAsync();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ChatGroup>> ListChatGroupsAsync()
        {
            try
            {
                return await _context.ChatGroups.ToListAsync();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
