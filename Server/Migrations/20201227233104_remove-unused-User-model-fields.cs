using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LyteChat.Server.Migrations
{
    public partial class removeunusedUsermodelfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"), 0, "0d7239ef-2e7c-4e2d-ad2c-bf26ca7fb97e", null, false, false, null, null, null, null, null, false, null, false, "Anonymous" },
                    { new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"), 0, "1f16af26-3cc6-4092-9748-ccfd2d7fdd3d", null, false, false, null, null, null, null, null, false, null, false, "Bob" },
                    { new Guid("d0099a4e-8d9a-4519-ad20-e9c072ca1b6e"), 0, "90626b54-f882-45a0-b131-437d7b7aec3a", null, false, false, null, null, null, null, null, false, null, false, "Carson" }
                });

            migrationBuilder.InsertData(
                table: "ChatGroups",
                columns: new[] { "ChatGroupId", "ChatGroupName", "Uuid" },
                values: new object[,]
                {
                    { 1L, "All Chat", new Guid("b626e69c-e99e-44a0-9c4d-9ab2c2fb03bb") },
                    { 2L, "second chat group", new Guid("b08aa272-ac2e-4168-a884-18b440e3fb70") },
                    { 3L, "third chat group", new Guid("185f58ce-8cb7-48c0-835c-bc8025e94539") }
                });

            migrationBuilder.InsertData(
                table: "ChatGroupUsers",
                columns: new[] { "ChatGroupId", "UserId", "Uuid" },
                values: new object[,]
                {
                    { 1L, new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"), new Guid("891b1d73-1ae0-4360-ac49-012de8f029ee") },
                    { 2L, new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"), new Guid("d9ac9fdb-4455-4aeb-a7e6-25b0f406426c") },
                    { 3L, new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"), new Guid("59ce7ddf-e575-4918-8e0b-347d3e148c24") },
                    { 1L, new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"), new Guid("2f6776c9-df49-4516-9fda-bcd2e3ae2dcf") },
                    { 2L, new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"), new Guid("1c3f9672-d1ce-4394-9462-ba8a858f611c") },
                    { 1L, new Guid("d0099a4e-8d9a-4519-ad20-e9c072ca1b6e"), new Guid("38ff209f-327b-4c3f-9633-5cc0c629e9ca") }
                });

            migrationBuilder.InsertData(
                table: "ChatMessages",
                columns: new[] { "ChatMessageId", "ChatGroupId", "Message", "UserId", "Uuid" },
                values: new object[,]
                {
                    { 1L, 1L, "first message", new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"), new Guid("2a8130e6-9701-4306-a202-a29c21b8235a") },
                    { 2L, 2L, "second message", new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"), new Guid("7760a372-5a47-46e3-97c3-304ab0168df2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("d0099a4e-8d9a-4519-ad20-e9c072ca1b6e") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 3L, new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e") });

            migrationBuilder.DeleteData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5b62c7f-a04f-483d-a9b2-25b8a589d873"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0099a4e-8d9a-4519-ad20-e9c072ca1b6e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d37f47df-3a46-421b-b5d2-4f09391e5d1e"));

            migrationBuilder.DeleteData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "Uuid",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
