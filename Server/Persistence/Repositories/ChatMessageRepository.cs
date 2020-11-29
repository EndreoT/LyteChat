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
    public class ChatMessageRepository: BaseRepository, IChatMessageRepository
    {
        public ChatMessageRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<ChatMessage>> ListMessagesForGroupAsync(string groupUuid)
        {
            try
            {
                return await _context.ChatMessages
                    .Where(message => message.ChatGroup.Uuid.ToString().Equals(groupUuid))
                    .Include(message => message.User)
                    .Include(message => message.ChatGroup)
                    .ToListAsync();
            } catch (InvalidOperationException e)
            {
                return null;
            }
        }
    }
}
