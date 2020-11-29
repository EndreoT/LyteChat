using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Data.Models;

namespace LearnBlazor.Data.RepositoryInterface.Repositories
{
    public interface IChatMessageRepository
    {
        public Task<IEnumerable<ChatMessage>> ListMessagesForGroupAsync(string group);
    }
}
