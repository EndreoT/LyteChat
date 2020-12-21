using Microsoft.EntityFrameworkCore;

using LearnBlazor.Server.Data.Models;

namespace LearnBlazor.Server.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public DbSet<ChatGroupUser> ChatGroupUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatGroupUser>()
                .HasKey(cgu => new { cgu.UserId, cgu.ChatGroupId});
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
                new User { UserId=1, Name = "Anonymous" },
                new User { UserId=2, Name = "Bob" },
                new User { UserId=3, Name = "Carson" },

            };

            var chatGroups = new ChatGroup[]
            {
                new ChatGroup{ChatGroupId=1, ChatGroupName="All Chat"},
                new ChatGroup{ChatGroupId=2, ChatGroupName="second chat group"},
                new ChatGroup{ChatGroupId=3, ChatGroupName="third chat group"},
            };

            var chatGroupUsers = new[]
            {
                new ChatGroupUser{UserId=1, ChatGroupId=1},
                new ChatGroupUser{UserId=1, ChatGroupId=2},
                new ChatGroupUser{UserId=1, ChatGroupId=3},
                new ChatGroupUser{UserId=2, ChatGroupId=1},
                new ChatGroupUser{UserId=2, ChatGroupId=2},
                new ChatGroupUser{UserId=3, ChatGroupId=1}
            };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<ChatGroup>().HasData(chatGroups);
            modelBuilder.Entity<ChatGroupUser>().HasData(chatGroupUsers);

            var chatMessages = new ChatMessage[]
            {
                new ChatMessage{
                    ChatMessageId = 1,
                    Message="first message",
                    UserId = users[0].UserId,
                    ChatGroupId = chatGroups[0].ChatGroupId
                },
                new ChatMessage{
                    ChatMessageId = 2,
                    Message="second message",
                    UserId = users[1].UserId,
                    ChatGroupId = chatGroups[1].ChatGroupId
                },
           };
            modelBuilder.Entity<ChatMessage>().HasData(chatMessages);


            base.OnModelCreating(modelBuilder);
        }
    }
}