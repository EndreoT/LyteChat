using LearnBlazor.Data.Models;
using LearnBlazor.Persistence.Context;
using System;
using System.Linq;

namespace LearnBlazor.Persistence
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

            var users = new User[]
            {
            new User{Name="Carson" },
            new User{Name="me" },
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var chatGroups = new ChatGroup[]
            {
            new ChatGroup{ChatGroupName="first chat group"},
            new ChatGroup{ChatGroupName="second chat group"},
            };
            foreach (ChatGroup c in chatGroups)
            {
                context.ChatGroups.Add(c);
            }
            context.SaveChanges();

            var chatMessages = new ChatMessage[]
            {
            new ChatMessage{
                Message="first",
                UserId = users.Single(u => u.Name == "Carson").UserId,
                ChatGroupId = chatGroups.Single(c => c.ChatGroupName == "first chat group").ChatGroupId
            },
            new ChatMessage{
                Message="second", 
                UserId = users.Single(u => u.Name == "me").UserId,
                ChatGroupId = chatGroups.Single(c => c.ChatGroupName == "first chat group").ChatGroupId
            },
           };
            foreach (ChatMessage c in chatMessages)
            {
                context.ChatMessages.Add(c);
            }
            context.SaveChanges();

            
        }
    }
}