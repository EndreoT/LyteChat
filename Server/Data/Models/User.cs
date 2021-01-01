using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LyteChat.Server.Data.Models
{
    public class User: IdentityUser<Guid>
    {
        public ICollection<ChatMessage> Messages { get; set; }

        public ICollection<ChatGroupUser> ChatGroupUsers { get; set; }
    }
}
