using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnBlazor.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            //    name: "Users",
            //    columns: table => new
            //    {
            //        UserId = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.UserId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChatGroupUsers",
            //    columns: table => new
            //    {
            //        UserId = table.Column<long>(type: "bigint", nullable: false),
            //        ChatGroupId = table.Column<long>(type: "bigint", nullable: false),
            //        Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChatGroupUsers", x => new { x.UserId, x.ChatGroupId });
            //        table.ForeignKey(
            //            name: "FK_ChatGroupUsers_ChatGroups_ChatGroupId",
            //            column: x => x.ChatGroupId,
            //            principalTable: "ChatGroups",
            //            principalColumn: "ChatGroupId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ChatGroupUsers_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "UserId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ChatMessages",
            //    columns: table => new
            //    {
            //        ChatMessageId = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<long>(type: "bigint", nullable: false),
            //        ChatGroupId = table.Column<long>(type: "bigint", nullable: false),
            //        Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ChatMessages", x => x.ChatMessageId);
            //        table.ForeignKey(
            //            name: "FK_ChatMessages_ChatGroups_ChatGroupId",
            //            column: x => x.ChatGroupId,
            //            principalTable: "ChatGroups",
            //            principalColumn: "ChatGroupId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ChatMessages_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "UserId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.InsertData(
            //    table: "ChatGroups",
            //    columns: new[] { "ChatGroupId", "ChatGroupName", "Uuid" },
            //    values: new object[,]
            //    {
            //        { 1L, "All Chat", new Guid("68a67d1d-ed19-4271-9792-c1e7277c5c92") },
            //        { 2L, "second chat group", new Guid("f002e119-c38c-4207-9bed-f925d290bcd1") },
            //        { 3L, "third chat group", new Guid("e4af9702-30e5-4d2e-acb7-9a3344c9749a") }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "UserId", "Name", "Uuid" },
            //    values: new object[,]
            //    {
            //        { 1L, "Anonymous", new Guid("1e263f3e-3cc0-41c3-88dc-94f334bd8fe9") },
            //        { 2L, "Bob", new Guid("dfd6101d-3aa8-402e-bb72-469a8aecd09c") },
            //        { 3L, "Carson", new Guid("b6148ca4-201e-4ee8-aa82-bf624abd7f6c") }
            //    });

            //migrationBuilder.InsertData(
            //    table: "ChatGroupUsers",
            //    columns: new[] { "ChatGroupId", "UserId", "Uuid" },
            //    values: new object[,]
            //    {
            //        { 1L, 1L, new Guid("f0fffe13-9e34-4ec6-bf84-7a65698749c9") },
            //        { 2L, 1L, new Guid("7c825425-cae5-4560-9569-2d1577532aaf") },
            //        { 3L, 1L, new Guid("2414b5ca-03bb-411a-a898-6fedbe345dab") },
            //        { 1L, 2L, new Guid("d53d1525-de64-43f0-b07e-a1d195b77f7c") },
            //        { 2L, 2L, new Guid("fac28d0f-a990-4c88-9b2b-92f51143cb98") },
            //        { 1L, 3L, new Guid("18634c88-c971-449a-8074-d702eb1c1f85") }
            //    });

            //migrationBuilder.InsertData(
            //    table: "ChatMessages",
            //    columns: new[] { "ChatMessageId", "ChatGroupId", "Message", "UserId", "Uuid" },
            //    values: new object[,]
            //    {
            //        { 1L, 1L, "first message", 1L, new Guid("c86b6173-9f1d-4550-a5cf-e0f56e56d2cb") },
            //        { 2L, 2L, "second message", 2L, new Guid("e3d03677-1c17-4d9c-9146-db01580d7b8c") }
            //    });

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
                name: "ChatGroupUsers");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ChatGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
