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
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public async Task<ChatGroup> GetAllChatAsync()
        {
            return await FindByName("ALL_CHAT");
        }

        public async Task<ChatGroup> FindByName(string chatGroupName)
        {
            try
            {
                return await _context.ChatGroups
                   .Where(chatGroup => chatGroup.ChatGroupName.Equals(chatGroupName))
                   .SingleAsync();
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public async Task AddChatGroupAsync(ChatGroup chatGroup)
        {
            await _context.ChatGroups.AddAsync(chatGroup);
        }
    }
}
