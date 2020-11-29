using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LearnBlazor.Shared.DataTransferObject
{
    public class ChatMessageDTO
    {
        public long ChatMessageId { get; set; }

        public string Message { get; set; }

        public long UserId { get; set; }
        public string UserName { get; set; }

        public long ChatGroupId { get; set; }

        public string ChatGroupName { get; set; }
    }
}
