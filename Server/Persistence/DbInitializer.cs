using System;
using System.Linq;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Server.Persistence.Context;

namespace LearnBlazor.Server.Persistence
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