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

            var users = new User[]
            {
            new User{Name="Carson" },
            new User{Name="Another User :)" },
            new User {Name="Anonymous"}
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var chatGroups = new ChatGroup[]
            {
            new ChatGroup{ChatGroupName="ALL_CHAT"},
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
                Message="first message",
                UserId = users.Single(u => u.Name == "Carson").UserId,
                ChatGroupId = chatGroups.Single(c => c.ChatGroupName == "ALL_CHAT").ChatGroupId
            },
            new ChatMessage{
                Message="second message", 
                UserId = users.Single(u => u.Name == "Another User :)").UserId,
                ChatGroupId = chatGroups.Single(c => c.ChatGroupName == "second chat group").ChatGroupId
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