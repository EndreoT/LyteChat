using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Shared.DataTransferObject;
using LyteChat.Shared.Communication;

namespace LyteChat.Server.Data.ServiceInterface
{
    public interface IChatMessageService: IServiceBase<ChatMessageDTO>
    {
        public Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroupAsync(Guid groupUuid);

        public Task<IEnumerable<ChatMessageDTO>> ListMessagesForAllChatGroupAsync();

        public Task<ChatMessageResponse> CreateChatMessageAsync(ChatMessageDTO chatMessageDTO);
    }
}
