using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Server.Data.Models
{
    public class ChatGroupUser: BaseModel
    {
        public ChatGroupUser() : base() { }

        public long UserId { get; set; }
        public User User { get; set; }

        public long ChatGroupId { get; set; }

        public ChatGroup ChatGroup { get; set; }
    }
}
