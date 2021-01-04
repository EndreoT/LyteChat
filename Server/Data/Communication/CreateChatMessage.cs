using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Server.Data.Models;

namespace LyteChat.Server.Data.Communication
{
    public class CreateChatMessage
    {
        public string Message { get; set; }
        public Guid ChatGroupUuid { get; set; }
        public User User { get; set; }
    }
}
