using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LyteChat.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("db436d52-d6cf-4c3f-9465-8361698a835c"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("603ad931-a965-4ae3-be9d-26d124550bb8"), new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("339fb0e4-a052-4263-84d0-72ffca4c9eff"), new Guid("f1ad6149-cbb0-4750-821b-d490069fbbaa") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c144eb3f-2c8e-41f9-99d4-3bc8c3faf877"));

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 3L, new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("bff5f162-d62a-45dd-94ec-c26395a89d47") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, new Guid("bff5f162-d62a-45dd-94ec-c26395a89d47") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("f1ad6149-cbb0-4750-821b-d490069fbbaa") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("339fb0e4-a052-4263-84d0-72ffca4c9eff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("603ad931-a965-4ae3-be9d-26d124550bb8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bff5f162-d62a-45dd-94ec-c26395a89d47"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f1ad6149-cbb0-4750-821b-d490069fbbaa"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5668b01e-8f9c-41ec-831d-8a0e76575f91"), "26587d7b-4702-4ba2-8126-4bc051ad7461", "Administrator", "ADMINISTRATOR" },
                    { new Guid("7e741158-e699-42ca-b7b0-09f292064e0f"), "a3e32fdb-33e1-45c3-bbfb-dd4f282e0f80", "Visitor", "VISITOR" },
                    { new Guid("27d35ef3-c7ff-4fbc-b636-aec6324e48a3"), "8659adfb-8907-44f4-a9f7-b10e139f07aa", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4"), 0, "51b1ad94-2980-4f38-8afe-2e54a3067b46", "admin@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEH251H0O8g/CdDCTCcHLn2RfUPXwf5JndNq/9c5G/ySnTIZy9TkK/dhT5LHcZq5d7w==", null, false, null, false, "Admin" },
                    { new Guid("069dc76d-dbab-46f2-8687-322b5afe4c52"), 0, "add70532-d63d-42b9-90ee-1efcd7e4c55d", "anonymous@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMd/FIS/APpabN/QQFP5iT9yecxIzzfFveeA9olQ5lT1uHKr2FJP0OLC5ej42oe/yw==", null, false, null, false, "Anonymous" },
                    { new Guid("2e03026f-8bc3-4a25-9e30-fa9ee17e9d75"), 0, "255f0551-d8f4-47c6-82eb-82e26cb5f54f", "bob@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOWci0cn6Pzh9PTwZkaGO/9YcwBy2881dd56g4EQzbhRS8kRb6A9kHmo4BG93nHb1w==", null, false, null, false, "Bob" },
                    { new Guid("dfe84360-9624-47cf-aab9-d9e19297a80b"), 0, "a5fe6bbd-1b55-4dd4-89d9-3d687379cc26", "carson@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKFX2jQYPa0k9Uk1wNDFw76oltext13BatQ//hFp9x546VtN4BBzCeADVy5jUPL62A==", null, false, null, false, "Carson" }
                });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("e988cf25-0bc0-4ce2-8f71-4fbf7157c619"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("2f3c3d86-4210-4303-97b4-d64a2c68bf48"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L,
                column: "Uuid",
                value: new Guid("840b0779-68f6-4f98-8d8b-2ac95f7a3cd3"));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5668b01e-8f9c-41ec-831d-8a0e76575f91"), new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4") },
                    { new Guid("27d35ef3-c7ff-4fbc-b636-aec6324e48a3"), new Guid("2e03026f-8bc3-4a25-9e30-fa9ee17e9d75") }
                });

            migrationBuilder.InsertData(
                table: "ChatGroupUsers",
                columns: new[] { "ChatGroupId", "UserId", "Uuid" },
                values: new object[,]
                {
                    { 1L, new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4"), new Guid("bc1b0ebb-0da6-406e-9bba-5077c2c110aa") },
                    { 2L, new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4"), new Guid("83f245a2-c6ab-4c88-a8f8-99ab1eb84430") },
                    { 3L, new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4"), new Guid("0df39c04-509b-4f76-bfd7-e637c1cc5c6e") },
                    { 1L, new Guid("069dc76d-dbab-46f2-8687-322b5afe4c52"), new Guid("0493ca84-7146-4aa0-be05-fb18f7eb1566") },
                    { 2L, new Guid("069dc76d-dbab-46f2-8687-322b5afe4c52"), new Guid("5e590794-be40-466c-a65f-0ffa919abb80") },
                    { 1L, new Guid("2e03026f-8bc3-4a25-9e30-fa9ee17e9d75"), new Guid("9638eede-4c1c-4d44-8aa5-07b01566bf8d") }
                });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L,
                columns: new[] { "UserId", "Uuid" },
                values: new object[] { new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4"), new Guid("659142f2-493e-46dd-bf3f-7b2337a22466") });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L,
                columns: new[] { "UserId", "Uuid" },
                values: new object[] { new Guid("069dc76d-dbab-46f2-8687-322b5afe4c52"), new Guid("60c2e324-985e-4476-9661-fca7f9aa18b7") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e741158-e699-42ca-b7b0-09f292064e0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("27d35ef3-c7ff-4fbc-b636-aec6324e48a3"), new Guid("2e03026f-8bc3-4a25-9e30-fa9ee17e9d75") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5668b01e-8f9c-41ec-831d-8a0e76575f91"), new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dfe84360-9624-47cf-aab9-d9e19297a80b"));

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("069dc76d-dbab-46f2-8687-322b5afe4c52") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, new Guid("069dc76d-dbab-46f2-8687-322b5afe4c52") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("2e03026f-8bc3-4a25-9e30-fa9ee17e9d75") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 3L, new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("27d35ef3-c7ff-4fbc-b636-aec6324e48a3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5668b01e-8f9c-41ec-831d-8a0e76575f91"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("069dc76d-dbab-46f2-8687-322b5afe4c52"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e03026f-8bc3-4a25-9e30-fa9ee17e9d75"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0c98efb-9dc0-4e95-8187-87f64c51d9c4"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("603ad931-a965-4ae3-be9d-26d124550bb8"), "46063d7d-e6d9-46a1-8f12-7add7655914e", "Administrator", "ADMINISTRATOR" },
                    { new Guid("db436d52-d6cf-4c3f-9465-8361698a835c"), "7a157a36-94b4-429c-8b43-8e14a052dbf9", "Visitor", "VISITOR" },
                    { new Guid("339fb0e4-a052-4263-84d0-72ffca4c9eff"), "830a8f8b-0b3e-4c2d-b54f-7b3110518c8c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d"), 0, "148c652f-5a51-4b8e-a0e4-9227632618ac", "admin@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEIYdpOUfJMT6wF29bH9WkBXfMwj01PtaHhB16cT6Ko42WnMEXDdJyjH+Wu+D7Ly/bQ==", null, false, null, false, "Admin" },
                    { new Guid("bff5f162-d62a-45dd-94ec-c26395a89d47"), 0, "3a3fc3e6-0611-4b47-9772-d6c5788b029d", "anonymous@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEENa1avl84+d4kUBqPSFGNh4oAItEpQHm9jwusg9ezCdyKMZCi0x+iALU7XSPBnkVA==", null, false, null, false, "Anonymous" },
                    { new Guid("f1ad6149-cbb0-4750-821b-d490069fbbaa"), 0, "9efed18f-f73e-40bc-9455-c46349d78cb5", "bob@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOGaycoc663J4shpIquivCy2FMOsi+LjiA6QUaaBDBkSt8eMbX2YSPGkBT+OcYuiuA==", null, false, null, false, "Bob" },
                    { new Guid("c144eb3f-2c8e-41f9-99d4-3bc8c3faf877"), 0, "b60e1533-01a9-41d3-9058-a4b45f9e4d7e", "carson@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKfNewvNkNWBvodDKEBAJfXOJN9O3GusTpogvlSYSiirdGAgXwz7m+Em4v0WzamVXg==", null, false, null, false, "Carson" }
                });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("bf3ea3b2-9156-462d-91b6-6c4073962593"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("9e06cb6b-b425-4824-8864-d6354e4c9ceb"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L,
                column: "Uuid",
                value: new Guid("8a2afda3-6648-47d8-a507-632770b45003"));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("603ad931-a965-4ae3-be9d-26d124550bb8"), new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d") },
                    { new Guid("339fb0e4-a052-4263-84d0-72ffca4c9eff"), new Guid("f1ad6149-cbb0-4750-821b-d490069fbbaa") }
                });

            migrationBuilder.InsertData(
                table: "ChatGroupUsers",
                columns: new[] { "ChatGroupId", "UserId", "Uuid" },
                values: new object[,]
                {
                    { 1L, new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d"), new Guid("412f3376-8d2d-4710-8e4e-d4105bfed06f") },
                    { 2L, new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d"), new Guid("d4cf1ce1-d88e-4f1b-901c-e266ca326d76") },
                    { 3L, new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d"), new Guid("c5a1bdaa-c712-446c-80a9-4efd01543dbe") },
                    { 1L, new Guid("bff5f162-d62a-45dd-94ec-c26395a89d47"), new Guid("b200320f-c487-4c0c-9cfe-0ed5915cf538") },
                    { 2L, new Guid("bff5f162-d62a-45dd-94ec-c26395a89d47"), new Guid("66cb1615-ba1a-4f42-879b-22a23c06d470") },
                    { 1L, new Guid("f1ad6149-cbb0-4750-821b-d490069fbbaa"), new Guid("1004b1f4-89ac-427f-8c35-629025660e75") }
                });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L,
                columns: new[] { "UserId", "Uuid" },
                values: new object[] { new Guid("10772896-b970-4128-84d0-a11c9fd6aa7d"), new Guid("a18df668-0b2f-4d80-8fce-83b090423e2f") });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L,
                columns: new[] { "UserId", "Uuid" },
                values: new object[] { new Guid("bff5f162-d62a-45dd-94ec-c26395a89d47"), new Guid("0776edf0-5740-4cf8-b240-0cdb6aa6198a") });
        }
    }
}
