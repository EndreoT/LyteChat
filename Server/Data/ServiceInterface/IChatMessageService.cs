using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Shared.DataTransferObject;
using LearnBlazor.Server.Services.Communication;

namespace LearnBlazor.Server.Data.ServiceInterface
{
    public interface IChatMessageService
    {
        public Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroupAsync(string groupUuid);

        public Task<ChatMessageResponse> CreateChatMessageAsync(ChatMessageDTO chatMessageDTO);
    }
}
