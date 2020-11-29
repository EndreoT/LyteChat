using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Data.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }

        public ICollection<ChatMessage> Messages { get; set; }

    }
}
