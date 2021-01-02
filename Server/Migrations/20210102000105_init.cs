using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LyteChat.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChatGroups",
            //    columns: table => new
            //    {
            //        ChatGroupId = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ChatGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChatGroups", x => x.ChatGroupId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChatGroupUsers",
            //    columns: table => new
            //    {
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ChatGroupId = table.Column<long>(type: "bigint", nullable: false),
            //        Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChatGroupUsers", x => new { x.UserId, x.ChatGroupId });
            //        table.ForeignKey(
            //            name: "FK_ChatGroupUsers_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ChatGroupUsers_ChatGroups_ChatGroupId",
            //            column: x => x.ChatGroupId,
            //            principalTable: "ChatGroups",
            //            principalColumn: "ChatGroupId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChatMessages",
            //    columns: table => new
            //    {
            //        ChatMessageId = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ChatGroupId = table.Column<long>(type: "bigint", nullable: false),
            //        Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChatMessages", x => x.ChatMessageId);
            //        table.ForeignKey(
            //            name: "FK_ChatMessages_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ChatMessages_ChatGroups_ChatGroupId",
            //            column: x => x.ChatGroupId,
            //            principalTable: "ChatGroups",
            //            principalColumn: "ChatGroupId",
            //            onDelete: ReferentialAction.Cascade);
                //});

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[,]
            //    {
            //        { new Guid("864da5d1-73d4-4062-b0c5-69553d6dbae6"), 0, "dfad42d0-2b1d-4d34-af2a-b6b8a3d128da", null, false, false, null, null, null, null, null, false, null, false, "Anonymous" },
            //        { new Guid("0259eef7-22ad-4342-b318-767cc199ffce"), 0, "04c1a103-abaa-49a1-a426-03c70ef8a3ad", null, false, false, null, null, null, null, null, false, null, false, "Bob" },
            //        { new Guid("7eded3c0-2a41-4536-a092-477d74b74576"), 0, "af4c4738-d519-4cef-b20c-9f596804af13", null, false, false, null, null, null, null, null, false, null, false, "Carson" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "ChatGroups",
            //    columns: new[] { "ChatGroupId", "ChatGroupName", "Uuid" },
            //    values: new object[,]
            //    {
            //        { 1L, "All Chat", new Guid("122be75e-4a47-4bb6-adbd-febc312ebe8d") },
            //        { 2L, "second chat group", new Guid("25324315-9652-4ade-a437-ebaf4701e64d") },
            //        { 3L, "third chat group", new Guid("cea5bfb9-1a46-4348-86e7-937a1238d789") }
            //    });

            //migrationBuilder.InsertData(
            //    table: "ChatGroupUsers",
            //    columns: new[] { "ChatGroupId", "UserId", "Uuid" },
            //    values: new object[,]
            //    {
            //        { 1L, new Guid("864da5d1-73d4-4062-b0c5-69553d6dbae6"), new Guid("202acb5b-54a1-41d8-9344-5ba93f8be24b") },
            //        { 2L, new Guid("864da5d1-73d4-4062-b0c5-69553d6dbae6"), new Guid("a843a20b-b30d-4e9a-9c3e-8fcf85599bc2") },
            //        { 3L, new Guid("864da5d1-73d4-4062-b0c5-69553d6dbae6"), new Guid("62e43557-a205-40b4-9268-d9c4a2d10a3c") },
            //        { 1L, new Guid("0259eef7-22ad-4342-b318-767cc199ffce"), new Guid("1fe29e06-0901-408a-9dbf-7d3a52aed05e") },
            //        { 2L, new Guid("0259eef7-22ad-4342-b318-767cc199ffce"), new Guid("56f4eda4-8b66-425b-a5ce-7b98831aeb76") },
            //        { 1L, new Guid("7eded3c0-2a41-4536-a092-477d74b74576"), new Guid("98b63f0a-081a-4c2f-bfb8-b446e2745262") }
            //    });

            //migrationBuilder.InsertData(
            //    table: "ChatMessages",
            //    columns: new[] { "ChatMessageId", "ChatGroupId", "Message", "UserId", "Uuid" },
            //    values: new object[,]
            //    {
            //        { 1L, 1L, "first message", new Guid("864da5d1-73d4-4062-b0c5-69553d6dbae6"), new Guid("c6a8e7f3-3cca-4d2f-98bf-4ad196f29b29") },
            //        { 2L, 2L, "second message", new Guid("0259eef7-22ad-4342-b318-767cc199ffce"), new Guid("f7efd295-da01-4bf3-90f1-edd5a22c61f1") }
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChatGroupUsers_ChatGroupId",
            //    table: "ChatGroupUsers",
            //    column: "ChatGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChatMessages_ChatGroupId",
            //    table: "ChatMessages",
            //    column: "ChatGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ChatMessages_UserId",
            //    table: "ChatMessages",
            //    column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChatGroupUsers");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChatGroups");
        }
    }
}
