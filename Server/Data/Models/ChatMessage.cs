using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Server.Data.Models
{
    public class ChatMessage: BaseModel
    {
        public ChatMessage() : base() { }
        public long ChatMessageId { get; set; }

        public string Message { get; set; }

        public long UserId { get; set; }

        public long ChatGroupId { get; set; }

        public User User { get; set; }
        public ChatGroup ChatGroup { get; set; }

    }
}
