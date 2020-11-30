using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Shared.DataTransferObject;

namespace LearnBlazor.Server.Data.ServiceInterface
{
    public interface IChatMessageService
    {
        public Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroupAsync(string groupUuid);
    }
}
