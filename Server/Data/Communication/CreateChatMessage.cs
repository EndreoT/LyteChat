using LyteChat.Server.Data.Models;
using System;

namespace LyteChat.Server.Data.Communication
{
    public class CreateChatMessage
    {
        public string Message { get; set; }
        public Guid ChatGroupUuid { get; set; }
        public User User { get; set; }
    }
}
