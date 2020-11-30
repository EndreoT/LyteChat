﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.Models;

namespace LearnBlazor.Server.Data.RepositoryInterface.Repositories
{
    public interface IChatMessageRepository: IBaseRepository<ChatMessage>
    {
        public Task<IEnumerable<ChatMessage>> ListMessagesForGroupAsync(string group);

        public Task CreateMessageAsync(ChatMessage chatMessage);
    }
}
