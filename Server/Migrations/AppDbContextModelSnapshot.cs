﻿// <auto-generated />
using System;
using LearnBlazor.Server.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearnBlazor.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.ChatGroup", b =>
                {
                    b.Property<long>("ChatGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("ChatGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatGroupId");

                    b.ToTable("ChatGroups");

                    b.HasData(
                        new
                        {
                            ChatGroupId = 1L,
                            ChatGroupName = "All Chat",
                            Uuid = new Guid("b626e69c-e99e-44a0-9c4d-9ab2c2fb03bb")
                        },
                        new
                        {
                            ChatGroupId = 2L,
                            ChatGroupName = "second chat group",
                            Uuid = new Guid("b08aa272-ac2e-4168-a884-18b440e3fb70")
                        },
                        new
                        {
                            ChatGroupId = 3L,
                            ChatGroupName = "third chat group",
                            Uuid = new Guid("185f58ce-8cb7-48c0-835c-bc8025e94539")
                        });
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.ChatGroupUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ChatGroupId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ChatGroupId");

                    b.HasIndex("ChatGroupId");

                    b.ToTable("ChatGroupUsers");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"),
                            ChatGroupId = 1L,
                            Uuid = new Guid("891b1d73-1ae0-4360-ac49-012de8f029ee")
                        },
                        new
                        {
                            UserId = new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"),
                            ChatGroupId = 2L,
                            Uuid = new Guid("d9ac9fdb-4455-4aeb-a7e6-25b0f406426c")
                        },
                        new
                        {
                            UserId = new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"),
                            ChatGroupId = 3L,
                            Uuid = new Guid("59ce7ddf-e575-4918-8e0b-347d3e148c24")
                        },
                        new
                        {
                            UserId = new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"),
                            ChatGroupId = 1L,
                            Uuid = new Guid("2f6776c9-df49-4516-9fda-bcd2e3ae2dcf")
                        },
                        new
                        {
                            UserId = new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"),
                            ChatGroupId = 2L,
                            Uuid = new Guid("1c3f9672-d1ce-4394-9462-ba8a858f611c")
                        },
                        new
                        {
                            UserId = new Guid("d0099a4e-8d9a-4519-ad20-e9c072ca1b6e"),
                            ChatGroupId = 1L,
                            Uuid = new Guid("38ff209f-327b-4c3f-9633-5cc0c629e9ca")
                        });
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.ChatMessage", b =>
                {
                    b.Property<long>("ChatMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ChatGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatMessageId");

                    b.HasIndex("ChatGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatMessages");

                    b.HasData(
                        new
                        {
                            ChatMessageId = 1L,
                            ChatGroupId = 1L,
                            Message = "first message",
                            UserId = new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"),
                            Uuid = new Guid("2a8130e6-9701-4306-a202-a29c21b8235a")
                        },
                        new
                        {
                            ChatMessageId = 2L,
                            ChatGroupId = 2L,
                            Message = "second message",
                            UserId = new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"),
                            Uuid = new Guid("7760a372-5a47-46e3-97c3-304ab0168df2")
                        });
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0d7239ef-2e7c-4e2d-ad2c-bf26ca7fb97e",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Anonymous"
                        },
                        new
                        {
                            Id = new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1f16af26-3cc6-4092-9748-ccfd2d7fdd3d",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Bob"
                        },
                        new
                        {
                            Id = new Guid("d0099a4e-8d9a-4519-ad20-e9c072ca1b6e"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "90626b54-f882-45a0-b131-437d7b7aec3a",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Carson"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.ChatGroupUser", b =>
                {
                    b.HasOne("LearnBlazor.Server.Data.Models.ChatGroup", "ChatGroup")
                        .WithMany("ChatGroupUsers")
                        .HasForeignKey("ChatGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnBlazor.Server.Data.Models.User", "User")
                        .WithMany("ChatGroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.ChatMessage", b =>
                {
                    b.HasOne("LearnBlazor.Server.Data.Models.ChatGroup", "ChatGroup")
                        .WithMany("Messages")
                        .HasForeignKey("ChatGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnBlazor.Server.Data.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("LearnBlazor.Server.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("LearnBlazor.Server.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("LearnBlazor.Server.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("LearnBlazor.Server.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnBlazor.Server.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("LearnBlazor.Server.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.ChatGroup", b =>
                {
                    b.Navigation("ChatGroupUsers");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.User", b =>
                {
                    b.Navigation("ChatGroupUsers");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
