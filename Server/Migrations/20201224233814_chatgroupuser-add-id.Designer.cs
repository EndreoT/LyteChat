﻿// <auto-generated />
using System;
using LearnBlazor.Server.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearnBlazor.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201224233814_chatgroupuser-add-id")]
    partial class chatgroupuseraddid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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
                            Uuid = new Guid("33820d5f-305d-4b96-8907-6fa6dafbdcef")
                        },
                        new
                        {
                            ChatGroupId = 2L,
                            ChatGroupName = "second chat group",
                            Uuid = new Guid("af4b47a5-9699-4e01-9830-f0673c5f6183")
                        },
                        new
                        {
                            ChatGroupId = 3L,
                            ChatGroupName = "third chat group",
                            Uuid = new Guid("f1e11a77-6874-449e-8ae3-35bf781ee801")
                        });
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.ChatGroupUser", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("ChatGroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("ChatGroupUserId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ChatGroupId");

                    b.HasIndex("ChatGroupId");

                    b.ToTable("ChatGroupUsers");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            ChatGroupId = 1L,
                            ChatGroupUserId = 0L,
                            Uuid = new Guid("fcaf1730-7ea3-45f2-9bb8-2f52f514d446")
                        },
                        new
                        {
                            UserId = 1L,
                            ChatGroupId = 2L,
                            ChatGroupUserId = 0L,
                            Uuid = new Guid("f81384a7-f13e-483c-97b4-4b948df0ce10")
                        },
                        new
                        {
                            UserId = 1L,
                            ChatGroupId = 3L,
                            ChatGroupUserId = 0L,
                            Uuid = new Guid("dce3c3a3-248d-4304-bd1c-c43de212f98e")
                        },
                        new
                        {
                            UserId = 2L,
                            ChatGroupId = 1L,
                            ChatGroupUserId = 0L,
                            Uuid = new Guid("8bc15b99-01ff-4cca-9147-f829cadac86d")
                        },
                        new
                        {
                            UserId = 2L,
                            ChatGroupId = 2L,
                            ChatGroupUserId = 0L,
                            Uuid = new Guid("7f8f806d-a9c9-4141-a45e-5d72ce4a0932")
                        },
                        new
                        {
                            UserId = 3L,
                            ChatGroupId = 1L,
                            ChatGroupUserId = 0L,
                            Uuid = new Guid("03efdf7d-8eac-4210-ba07-743ed934fcbb")
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

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

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
                            UserId = 1L,
                            Uuid = new Guid("a2bc548b-1ed5-42cc-9c82-f2ccc6594743")
                        },
                        new
                        {
                            ChatMessageId = 2L,
                            ChatGroupId = 2L,
                            Message = "second message",
                            UserId = 2L,
                            Uuid = new Guid("f0d0f05c-7d31-4d9e-b418-35e685c14cf1")
                        });
                });

            modelBuilder.Entity("LearnBlazor.Server.Data.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            Name = "Anonymous",
                            Uuid = new Guid("748f55c3-3d67-4347-95fa-e97ef33c907d")
                        },
                        new
                        {
                            UserId = 2L,
                            Name = "Bob",
                            Uuid = new Guid("90c63ff5-bc48-4135-8bb0-d8da05b7aa16")
                        },
                        new
                        {
                            UserId = 3L,
                            Name = "Carson",
                            Uuid = new Guid("6ea0fe29-2fa7-4cca-bf83-5645f275fc8a")
                        });
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
