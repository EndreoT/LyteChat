﻿using LyteChat.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LyteChat.Server.Persistence.Context
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
            modelBuilder.Entity<ChatGroup>()
                .HasIndex(chatGroup => chatGroup.ChatGroupName)
                .IsUnique();

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

            Role[] roles =
            {
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = Role.Admin,
                    NormalizedName = Role.Admin.ToUpper()
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = Role.AnonymousUser,
                    NormalizedName = Role.AnonymousUser.ToUpper()
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = Role.AuthenticatedUser,
                    NormalizedName = Role.AuthenticatedUser.ToUpper()
                }

            };
            modelBuilder.Entity<Role>().HasData(roles);

            var hasher = new PasswordHasher<User>();
            var users = new User[]
            {
                new User {
                     Id=Guid.NewGuid(),
                     UserName = "Admin",
                     NormalizedUserName = "Admin".ToUpper(),
                     Email = "admin@email.com",
                     NormalizedEmail = "admin@email.com".ToUpper(),
                     PasswordHash = hasher.HashPassword(null, "pass$1"),
                 },
                 new User {
                     Id=Guid.NewGuid(),
                     UserName = "Anonymous",
                     NormalizedUserName = "Anonymous".ToUpper(),
                     Email = User.AnonymousUserEmail,
                     NormalizedEmail = User.AnonymousUserEmail.ToUpper(),
                     PasswordHash = hasher.HashPassword(null, "pass$2"),
                 },
                 new User {
                     Id=Guid.NewGuid(),
                     UserName = "Bob" ,
                     NormalizedUserName = "Bob".ToUpper(),
                     Email = "bob@email.com",
                     NormalizedEmail = "bob@email.com".ToUpper(),
                     PasswordHash = hasher.HashPassword(null, "pass$3"),
                 },
                 new User {
                     Id=Guid.NewGuid(),
                     UserName = "Alice",
                     NormalizedUserName = "Alice".ToUpper(),
                     Email = "alice@email.com",
                     NormalizedEmail = "alice@email.com".ToUpper(),
                     PasswordHash = hasher.HashPassword(null, "pass$4"),
                 }
            };
            modelBuilder.Entity<User>().HasData(users);

            List<IdentityUserRole<Guid>> userRoles = new List<IdentityUserRole<Guid>>();
            foreach (User user in users)
            {
                Guid roleId;
                if (user.UserName == "Admin")
                {
                    roleId = roles[0].Id;
                }
                else if (user.UserName == "Anonymous")
                {
                    roleId = roles[1].Id;
                }
                else
                {
                    roleId = roles[2].Id;
                }
                userRoles.Add(
                    new IdentityUserRole<Guid>
                    {
                        RoleId = roleId, // for admin username
                        UserId = user.Id  // for admin role
                    });
            }
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);

            var chatGroups = new ChatGroup[]
            {
                 new ChatGroup{ChatGroupId=1, ChatGroupName=ChatGroup.AllChat},
                 new ChatGroup{ChatGroupId=2, ChatGroupName="second chat group"},
                 new ChatGroup{ChatGroupId=3, ChatGroupName="third chat group"},
            };

            var chatGroupUsers = from user in users select new ChatGroupUser { UserId = user.Id, ChatGroupId = 1 };

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


            modelBuilder.Entity<ChatGroup>().HasData(chatGroups);
            modelBuilder.Entity<ChatGroupUser>().HasData(chatGroupUsers);
            modelBuilder.Entity<ChatMessage>().HasData(chatMessages);

            base.OnModelCreating(modelBuilder);
        }
    }
}