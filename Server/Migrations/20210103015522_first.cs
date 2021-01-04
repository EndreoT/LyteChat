using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LyteChat.Server.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("dc0fd1ca-cb14-49bf-bf97-508374eb6747"), "f14ae84b-16b3-4b89-93a6-092eb45d4b59", "Administrator", "ADMINISTRATOR" },
                    { new Guid("65cb9583-e70e-4816-b1b7-665e9abb6e5a"), "521d26c5-ef12-4e5f-a378-58f6e94b6f4f", "Visitor", "VISITOR" },
                    { new Guid("1e78b1bb-85ac-4059-bf92-9ff48b24d632"), "e230c347-e77f-4af7-8c2e-a8869a3e43fa", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a"), 0, "665c0df8-7c05-4905-bb01-9ac4ff2122cb", "admin@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENJjqEAgituSp+Qsj70DECl+C/TW1U/uCYR961E80Gd04DgKWZXKHMFimJRO2Vjqqg==", null, false, null, false, "Admin" },
                    { new Guid("c9854360-6bbe-452b-b583-47ad9a3506d5"), 0, "975d375e-10d1-4923-aab4-a5c5194f82b2", "anonymous@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEFHr4OYjmCO/JdI6lWrz6Alsryk9dU02Jw62PiDi1tYMBYZgpH8WjF5K/woxVnypjw==", null, false, null, false, "Anonymous" },
                    { new Guid("4763650c-2954-4acc-87aa-819aea6d5ee9"), 0, "4c52b9c9-8262-45e7-bb78-27d8292d29d9", "bob@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEL6qjSqeR1jvbb7s4EI6jnp9YFOw6TYlf7CK5HMr13LycaEUuyd1db8y3K04z8l4CQ==", null, false, null, false, "Bob" },
                    { new Guid("9b10187f-7c17-4ffd-97ac-4aa1c26023d2"), 0, "8331fa90-93d7-40ec-a477-11bf12781f95", "carson@email.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGOzvfqEnFxgxX5Tw54vp1/v7QyMVSTMi1HLmUsrLa31tqihAuBBBU8WnAZLAPRuZA==", null, false, null, false, "Carson" }
                });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("49d42e21-1dfe-4554-bc05-6c5ee57efa0e"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("32e6062e-291a-4dcd-92ab-8f5ce0c387a6"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L,
                column: "Uuid",
                value: new Guid("f2cf599a-6318-424b-83e7-960cda4924f8"));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("dc0fd1ca-cb14-49bf-bf97-508374eb6747"), new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a") },
                    { new Guid("1e78b1bb-85ac-4059-bf92-9ff48b24d632"), new Guid("4763650c-2954-4acc-87aa-819aea6d5ee9") }
                });

            migrationBuilder.InsertData(
                table: "ChatGroupUsers",
                columns: new[] { "ChatGroupId", "UserId", "Uuid" },
                values: new object[,]
                {
                    { 1L, new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a"), new Guid("013575d1-5400-4ec9-98b2-f85c54aab323") },
                    { 2L, new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a"), new Guid("25bbfb41-9875-4d12-ac8c-01c7a7e42372") },
                    { 3L, new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a"), new Guid("851cbffd-33cd-4f01-bcc1-1f3f56ef7aac") },
                    { 1L, new Guid("c9854360-6bbe-452b-b583-47ad9a3506d5"), new Guid("5b52cc3f-509a-4d02-b31a-683210c61058") },
                    { 2L, new Guid("c9854360-6bbe-452b-b583-47ad9a3506d5"), new Guid("d5c2354e-a608-4e40-b961-090aa88c1fee") },
                    { 1L, new Guid("4763650c-2954-4acc-87aa-819aea6d5ee9"), new Guid("e9e47e2e-016a-4135-af73-1e88f7aa1294") }
                });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L,
                columns: new[] { "UserId", "Uuid" },
                values: new object[] { new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a"), new Guid("aa805e90-20d9-4bf9-a208-1dac26047cd5") });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L,
                columns: new[] { "UserId", "Uuid" },
                values: new object[] { new Guid("c9854360-6bbe-452b-b583-47ad9a3506d5"), new Guid("810fbc5d-7f8c-4b4d-8d30-42468610edca") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65cb9583-e70e-4816-b1b7-665e9abb6e5a"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1e78b1bb-85ac-4059-bf92-9ff48b24d632"), new Guid("4763650c-2954-4acc-87aa-819aea6d5ee9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dc0fd1ca-cb14-49bf-bf97-508374eb6747"), new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b10187f-7c17-4ffd-97ac-4aa1c26023d2"));

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("4763650c-2954-4acc-87aa-819aea6d5ee9") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 3L, new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("c9854360-6bbe-452b-b583-47ad9a3506d5") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, new Guid("c9854360-6bbe-452b-b583-47ad9a3506d5") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e78b1bb-85ac-4059-bf92-9ff48b24d632"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc0fd1ca-cb14-49bf-bf97-508374eb6747"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4763650c-2954-4acc-87aa-819aea6d5ee9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b8c3dfb0-866a-453f-9fef-ce17cff7e20a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c9854360-6bbe-452b-b583-47ad9a3506d5"));

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
    }
}
