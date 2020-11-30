using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Server.Data.Models
{
    public class User: BaseModel
    {
        public User() : base() { }
        public long UserId { get; set; }
        public string Name { get; set; }

        public ICollection<ChatMessage> Messages { get; set; }

    }
}
