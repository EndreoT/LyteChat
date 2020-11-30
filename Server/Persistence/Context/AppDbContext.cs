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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //builder.Entity<ChatGroup>().HasData
            //(
            //    new ChatGroup
            //    {
            //        ChatGroupID = 1,
            //        ChatGroupName = "Group 1",
            //    },
            //    new ChatGroup
            //    {
            //        ChatGroupID = 2,
            //        ChatGroupName = "Group 2",
            //    }
            //);
        }
    }
}