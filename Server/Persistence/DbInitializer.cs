using System;
using System.Linq;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Persistence.Context;

namespace LyteChat.Server.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
           context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
        }
    }
}