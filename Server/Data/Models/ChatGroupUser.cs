using System;

namespace LyteChat.Server.Data.Models
{
    public class ChatGroupUser : BaseModel
    {
        public ChatGroupUser() : base() { }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public long ChatGroupId { get; set; }

        public ChatGroup ChatGroup { get; set; }
    }
}
