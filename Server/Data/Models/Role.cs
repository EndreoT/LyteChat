using Microsoft.AspNetCore.Identity;
using System;

namespace LyteChat.Server.Data.Models
{
    public class Role : IdentityRole<Guid>
    {
        public const string Admin = "Admin";
        public const string AuthenticatedUser = "AuthenticatedUser";
        public const string AnonymousUser = "AnonymousUser";
    }
}
