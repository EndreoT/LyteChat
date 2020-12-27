using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LearnBlazor.Server.Data.Models;

namespace LearnBlazor.Server.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public DbSet<ChatGroupUser> ChatGroupUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatGroupUser>()
                .HasKey(cgu => new { cgu.UserId, cgu.ChatGroupId });
            modelBuilder.Entity<ChatGroupUser>()
                .HasOne(cgu => cgu.User)
                .WithMany(u => u.ChatGroupUsers)
                .HasForeignKey(cgu => cgu.UserId);
            modelBuilder.Entity<ChatGroupUser>()
                .HasOne(cgu => cgu.ChatGroup)
                .WithMany(cg => cg.ChatGroupUsers)
                .HasForeignKey(cgu => cgu.ChatGroupId);

            var users = new User[]
            {
                 new User { Id=Guid.NewGuid(), UserName = "Anonymous" },
                 new User { Id=Guid.NewGuid(), UserName = "Bob" },
                 new User { Id=Guid.NewGuid(), UserName = "Carson" },

            };

            var chatGroups = new ChatGroup[]
            {
                 new ChatGroup{ChatGroupId=1, ChatGroupName="All Chat"},
                 new ChatGroup{ChatGroupId=2, ChatGroupName="second chat group"},
                 new ChatGroup{ChatGroupId=3, ChatGroupName="third chat group"},
            };

            var chatGroupUsers = new[]
            {
                 new ChatGroupUser{UserId=users[0].Id, ChatGroupId=1},
                 new ChatGroupUser{UserId=users[0].Id, ChatGroupId=2},
                 new ChatGroupUser{UserId=users[0].Id, ChatGroupId=3},
                 new ChatGroupUser{UserId=users[1].Id, ChatGroupId=1},
                 new ChatGroupUser{UserId=users[1].Id, ChatGroupId=2},
                 new ChatGroupUser{UserId=users[2].Id, ChatGroupId=1}
             };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<ChatGroup>().HasData(chatGroups);
            modelBuilder.Entity<ChatGroupUser>().HasData(chatGroupUsers);

            var chatMessages = new ChatMessage[]
            {
                 new ChatMessage{
                     ChatMessageId = 1,
                     Message="first message",
                     UserId = users[0].Id,
                     ChatGroupId = chatGroups[0].ChatGroupId
                 },
                 new ChatMessage{
                     ChatMessageId = 2,
                     Message="second message",
                     UserId = users[1].Id,
                     ChatGroupId = chatGroups[1].ChatGroupId
                 },
           };
            modelBuilder.Entity<ChatMessage>().HasData(chatMessages);

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Name = "Visitor",
                    NormalizedName = "VISITOR"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });


            base.OnModelCreating(modelBuilder);
        }
    }
}