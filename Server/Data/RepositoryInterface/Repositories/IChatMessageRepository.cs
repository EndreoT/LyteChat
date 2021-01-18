using LyteChat.Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.RepositoryInterface.Repositories
{
    public interface IChatMessageRepository : IBaseRepository<ChatMessage>
    {
        public Task<IEnumerable<ChatMessage>> ListMessagesForGroupAsync(Guid group);

        public Task AddMessageAsync(ChatMessage chatMessage);
    }
}
