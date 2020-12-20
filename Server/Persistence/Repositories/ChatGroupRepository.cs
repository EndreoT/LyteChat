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

        public async Task<ChatGroup> GetByUuidAsync(Guid uuid)
        {
            try
            {
                return await _context
                    .ChatGroups
                    .Where(chatGroup => chatGroup.Uuid.Equals(uuid)).SingleAsync();
            }
            catch (InvalidOperationException e)
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
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public async Task<ChatGroup> GetAllChatAsync()
        {
            try
            {
                return await _context.ChatGroups
                   .Where(chatGroup => chatGroup.ChatGroupName.Equals("ALL_CHAT"))
                   .SingleAsync();
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }
    }
}
