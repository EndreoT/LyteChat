using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Data.Models;

namespace LearnBlazor.Data.RepositoryInterface.Repositories
{
    interface IChatGroupRepository
    {
        public Task<ChatGroup> GetByUUIdAsync(Guid uuid);

        public Task<IEnumerable<ChatGroup>> ListChatGroupsAsync();
    }
}
