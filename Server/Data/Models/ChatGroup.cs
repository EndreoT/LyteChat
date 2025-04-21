using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LyteChat.Server.Data.Models
{
    public class ChatGroup : BaseModel
    {
        public const string AllChat = "All Chat";

        public ChatGroup() : base() { }

        [Required]
        public long ChatGroupId { get; set; }

        [Required]
        public required string ChatGroupName { get; set; }

        public  ICollection<ChatMessage> Messages { get; set; }= new List<ChatMessage>();

        public ICollection<ChatGroupUser> ChatGroupUsers { get; set; } = new List<ChatGroupUser>();
    }
}
