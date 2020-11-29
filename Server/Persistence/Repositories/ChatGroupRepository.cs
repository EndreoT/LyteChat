using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Persistence.Context;
using LearnBlazor.Data.Models;
using LearnBlazor.Data.RepositoryInterface.Repositories;

namespace LearnBlazor.Persistence.Repositories
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
