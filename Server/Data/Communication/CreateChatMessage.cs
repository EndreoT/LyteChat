using LyteChat.Server.Data.Models;
using System;

namespace LyteChat.Server.Data.Communication
{
    public class CreateChatMessage
    {
        
        public required string Message { get; set; }
        
        public Guid ChatGroupUuid { get; set; }
        
        public required User User { get; set; }
    }
}
