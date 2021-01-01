using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Server.Data.Models;

namespace LyteChat.Server.Data.RepositoryInterface.Repositories
{
    public interface IChatGroupRepository: IBaseRepository<ChatGroup>
    {
        public Task<IEnumerable<ChatGroup>> ListChatGroupsAsync();

        public Task<ChatGroup> GetAllChatAsync();

    }
}
