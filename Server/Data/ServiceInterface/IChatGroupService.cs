using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Shared.DataTransferObject;

namespace LearnBlazor.Server.Data.ServiceInterface
{
    public interface IChatGroupService: IServiceBase<ChatGroupDTO>
    {
        public Task<IEnumerable<ChatGroupDTO>> ListChatGroupsAsync();

        public Task<ChatGroupDTO> GetAllChatAsync();
    }
}
