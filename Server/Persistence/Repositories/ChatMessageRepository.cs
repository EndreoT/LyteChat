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

        public async Task AddMessageAsync(ChatMessage chatMessage)
        {
            await _context.ChatMessages.AddAsync(chatMessage);
        }

        public async Task<ChatMessage> GetByUuid(Guid uuid)
        {
            try
            {
                return await _context
                    .ChatMessages
                    .Where(chatMessage => chatMessage.Uuid.Equals(uuid)).SingleAsync();

            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
