using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Server.Data.Models
{
    public class ChatGroup: BaseModel
    {
        public ChatGroup() : base() { }
        public long ChatGroupId { get; set; }

        public string ChatGroupName { get; set; }

        public ICollection<ChatMessage> Messages { get; set; }
    }
}
