using LyteChat.Shared.DataTransferObject;
using LyteChat.Shared.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.ServiceInterface
{
    public interface IChatGroupService : IServiceBase<ChatGroupDTO>
    {
        public Task<IEnumerable<ChatGroupDTO>> ListChatGroupsAsync();

        public Task<ChatGroupDTO> GetAllChatAsync();

        public Task<ChatGroupResponse> CreateChatGroupAsync(ChatGroupDTO chatGroupDTO);
    }
}
