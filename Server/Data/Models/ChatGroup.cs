using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Data.Models
{
    public class ChatGroup
    {
        public long ChatGroupId { get; set; }
        public Guid Uuid { get; set; }

        public string ChatGroupName { get; set; }

        public ICollection<ChatMessage> Messages { get; set; }

        public ChatGroup()
        {
            Uuid = Guid.NewGuid();
        }
    }
}
