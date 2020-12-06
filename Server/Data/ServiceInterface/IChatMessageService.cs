using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Shared.DataTransferObject;
using LearnBlazor.Shared.Communication;

namespace LearnBlazor.Server.Data.ServiceInterface
{
    public interface IChatMessageService
    {
        public Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroupAsync(Guid groupUuid);

        public Task<IEnumerable<ChatMessageDTO>> ListMessagesForAllChatGroupAsync();

        public Task<ChatMessageResponse> CreateChatMessageAsync(ChatMessageDTO chatMessageDTO);
    }
}
