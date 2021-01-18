using LyteChat.Server.Persistence.Context;
using System.Linq;

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