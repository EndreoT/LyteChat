using System;
using System.ComponentModel.DataAnnotations;

namespace LyteChat.Server.Data.Models
{
    public class ChatMessage : BaseModel
    {
        public ChatMessage() : base() { }
        public long ChatMessageId { get; set; }

        [Required]
        public required string Message { get; set; }

        public Guid UserId { get; set; }

        public long ChatGroupId { get; set; }

        public User? User { get; set; }
        public ChatGroup? ChatGroup { get; set; }

    }
}
