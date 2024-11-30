using LyteChat.Server.Data.Communication;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyteChat.Server.Data.ServiceInterface
{
    public interface IChatMessageService : IServiceBase<ChatMessageDTO>
    {
        public Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroupAsync(Guid groupUuid);

        public Task<IEnumerable<ChatMessageDTO>> ListMessagesForAllChatGroupAsync();

        public Task<ChatMessageResponse> CreateChatMessageAsync(CreateChatMessage chatMessage);
    }
}
