using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LyteChat.Server.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public const string AnonymousUserEmail = "anonymous@email.com";

        public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();

        public ICollection<ChatGroupUser> ChatGroupUsers { get; set; } = new List<ChatGroupUser>();

        public required new string UserName { get; set; }
    }
}
