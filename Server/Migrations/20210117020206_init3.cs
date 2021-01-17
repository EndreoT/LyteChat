using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LyteChat.Server.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("16732416-1be8-46f0-a30c-4ba2d6261855"), new Guid("06fba9ff-1503-4682-a1a9-52e28f4b84db") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("16732416-1be8-46f0-a30c-4ba2d6261855"), new Guid("3cb9148d-41b6-4a5a-920a-b615b5d57945") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4fc27e2c-2c2e-44ef-8703-766417390eb4"), new Guid("800e8351-91d2-47c0-b91f-c60a2b073e0f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4c5c70db-ebfb-4ed1-8122-92a5e60a1931"), new Guid("f69eb10a-d216-47de-9c87-f44591f0aa48") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("06fba9ff-1503-4682-a1a9-52e28f4b84db") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("3cb9148d-41b6-4a5a-920a-b615b5d57945") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("800e8351-91d2-47c0-b91f-c60a2b073e0f") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("f69eb10a-d216-47de-9c87-f44591f0aa48") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16732416-1be8-46f0-a30c-4ba2d6261855"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4c5c70db-ebfb-4ed1-8122-92a5e60a1931"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4fc27e2c-2c2e-44ef-8703-766417390eb4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06fba9ff-1503-4682-a1a9-52e28f4b84db"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3cb9148d-41b6-4a5a-920a-b615b5d57945"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("800e8351-91d2-47c0-b91f-c60a2b073e0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f69eb10a-d216-47de-9c87-f44591f0aa48"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ChatGroupUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ChatGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("17f05abf-3023-4ef7-ab5d-f4a2d5492e72"), "3e789119-2194-4054-b394-f7e32f67ce46", "Admin", "ADMIN" },
                    { new Guid("c98d5568-dd2a-473e-8afe-21109da4b197"), "a59295f9-0c68-4043-9f82-2f37318c141a", "AnonymousUser", "ANONYMOUSUSER" },
                    { new Guid("b10c21dc-d016-4b65-96c9-e5c623cdeb97"), "33cb1905-24ab-4c0c-a037-080436059ba4", "AuthenticatedUser", "AUTHENTICATEDUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("72a2d202-c709-4ee2-a75d-f0e9e6398ac4"), 0, "c03ddace-465e-47ca-b047-6de550120b8c", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEDKPGZLykrCI9j4T5Sp6UEcYz1GeJRTfaydpCSH8+oZjw6FuxUCpr+kDUzRsk4zMeg==", null, false, null, false, "Admin" },
                    { new Guid("73db8bd2-931d-42ea-9da2-1bddf803f28e"), 0, "972ff007-90f9-4141-8054-534d12ac4e71", "anonymous@email.com", false, false, null, "ANONYMOUS@EMAIL.COM", "ANONYMOUS", "AQAAAAEAACcQAAAAEGW5XOi7gKaoQyd2dGg04iB18Hx9oKCBKJ1kCfvdwtbBo3IXXW+022zMRn1fo23nlA==", null, false, null, false, "Anonymous" },
                    { new Guid("3bf8d405-1745-46b1-8cfc-404f87f5617c"), 0, "5fb5f34a-fddc-4de4-9313-3ca0cf7ffe8a", "bob@email.com", false, false, null, "BOB@EMAIL.COM", "BOB", "AQAAAAEAACcQAAAAEPsTiSBnxMTIiQUle71P/FnPRL7dD1UFC9cfsNLp3n05o33wl+t8ef6n4Q8CziraPA==", null, false, null, false, "Bob" },
                    { new Guid("8448f056-7e33-4642-9c7f-57d634e0a2ef"), 0, "a26580f1-15e8-4f43-a0c9-de7422bfd1b1", "alice@email.com", false, false, null, "ALICE@EMAIL.COM", "ALICE", "AQAAAAEAACcQAAAAEFn9owo1WNTsULRqtomiBIUXTgfY5WB/HijGbwvPCF/3tokoknWcY0eg3P8rNLvUHA==", null, false, null, false, "Alice" }
                });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 2, 6, 251, DateTimeKind.Local).AddTicks(4681), new Guid("5d9be073-1d8d-4d41-8e0c-2a016ea3d029") });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 2, 6, 254, DateTimeKind.Local).AddTicks(103), new Guid("75b77cc0-0e3e-447f-8c26-ebb69ff08e2e") });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 2, 6, 254, DateTimeKind.Local).AddTicks(135), new Guid("7db1576b-e8d0-43c1-9796-2d9693dc9d02") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("17f05abf-3023-4ef7-ab5d-f4a2d5492e72"), new Guid("72a2d202-c709-4ee2-a75d-f0e9e6398ac4") },
                    { new Guid("c98d5568-dd2a-473e-8afe-21109da4b197"), new Guid("73db8bd2-931d-42ea-9da2-1bddf803f28e") },
                    { new Guid("b10c21dc-d016-4b65-96c9-e5c623cdeb97"), new Guid("3bf8d405-1745-46b1-8cfc-404f87f5617c") },
                    { new Guid("b10c21dc-d016-4b65-96c9-e5c623cdeb97"), new Guid("8448f056-7e33-4642-9c7f-57d634e0a2ef") }
                });

            migrationBuilder.InsertData(
                table: "ChatGroupUsers",
                columns: new[] { "ChatGroupId", "UserId", "CreatedOn", "Uuid" },
                values: new object[,]
                {
                    { 1L, new Guid("72a2d202-c709-4ee2-a75d-f0e9e6398ac4"), new DateTime(2021, 1, 16, 18, 2, 6, 254, DateTimeKind.Local).AddTicks(4900), new Guid("9b20eaca-9d46-4b94-8a8f-72a00f4d2619") },
                    { 1L, new Guid("73db8bd2-931d-42ea-9da2-1bddf803f28e"), new DateTime(2021, 1, 16, 18, 2, 6, 254, DateTimeKind.Local).AddTicks(5679), new Guid("2f50a777-67da-4536-9436-c5f377789dba") },
                    { 1L, new Guid("3bf8d405-1745-46b1-8cfc-404f87f5617c"), new DateTime(2021, 1, 16, 18, 2, 6, 254, DateTimeKind.Local).AddTicks(5690), new Guid("5ba98ba3-4ec1-4878-a133-25929bdc9649") },
                    { 1L, new Guid("8448f056-7e33-4642-9c7f-57d634e0a2ef"), new DateTime(2021, 1, 16, 18, 2, 6, 254, DateTimeKind.Local).AddTicks(5693), new Guid("8c2a21f2-83f2-4167-b7d7-0a81385f029b") }
                });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UserId", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 2, 6, 254, DateTimeKind.Local).AddTicks(1781), new Guid("72a2d202-c709-4ee2-a75d-f0e9e6398ac4"), new Guid("dab347ed-96ea-447c-ab26-163668f91069") });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UserId", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 2, 6, 254, DateTimeKind.Local).AddTicks(3408), new Guid("73db8bd2-931d-42ea-9da2-1bddf803f28e"), new Guid("9fb2bbac-95b0-4144-92ce-bc4eeb0a2324") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b10c21dc-d016-4b65-96c9-e5c623cdeb97"), new Guid("3bf8d405-1745-46b1-8cfc-404f87f5617c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("17f05abf-3023-4ef7-ab5d-f4a2d5492e72"), new Guid("72a2d202-c709-4ee2-a75d-f0e9e6398ac4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c98d5568-dd2a-473e-8afe-21109da4b197"), new Guid("73db8bd2-931d-42ea-9da2-1bddf803f28e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b10c21dc-d016-4b65-96c9-e5c623cdeb97"), new Guid("8448f056-7e33-4642-9c7f-57d634e0a2ef") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("3bf8d405-1745-46b1-8cfc-404f87f5617c") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("72a2d202-c709-4ee2-a75d-f0e9e6398ac4") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("73db8bd2-931d-42ea-9da2-1bddf803f28e") });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, new Guid("8448f056-7e33-4642-9c7f-57d634e0a2ef") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17f05abf-3023-4ef7-ab5d-f4a2d5492e72"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b10c21dc-d016-4b65-96c9-e5c623cdeb97"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c98d5568-dd2a-473e-8afe-21109da4b197"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3bf8d405-1745-46b1-8cfc-404f87f5617c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("72a2d202-c709-4ee2-a75d-f0e9e6398ac4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("73db8bd2-931d-42ea-9da2-1bddf803f28e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8448f056-7e33-4642-9c7f-57d634e0a2ef"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ChatMessages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ChatGroupUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ChatGroups",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4c5c70db-ebfb-4ed1-8122-92a5e60a1931"), "f61861e6-f2b3-4e02-8375-4de21cbf26d5", "Admin", "ADMIN" },
                    { new Guid("4fc27e2c-2c2e-44ef-8703-766417390eb4"), "263b7f80-84f6-4c39-acff-a53304b4d8d5", "AnonymousUser", "ANONYMOUSUSER" },
                    { new Guid("16732416-1be8-46f0-a30c-4ba2d6261855"), "f8519df3-97b5-430a-b543-aae92ff19287", "AuthenticatedUser", "AUTHENTICATEDUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("f69eb10a-d216-47de-9c87-f44591f0aa48"), 0, "6f61832c-60aa-47ae-8268-a873f4a39ac7", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAECcSC2k2A3ebCslDrvFIJpPdC/OJV1dvM/zIj94KW4Lu7UgarX0p3ZTrdGQJ8r/1qw==", null, false, null, false, "Admin" },
                    { new Guid("800e8351-91d2-47c0-b91f-c60a2b073e0f"), 0, "7b7b5ae1-ed3e-48d7-9806-29fa665093b9", "anonymous@email.com", false, false, null, "ANONYMOUS@EMAIL.COM", "ANONYMOUS", "AQAAAAEAACcQAAAAEOQfAgJGnj6XjVmP+3f64Wc77EKResnITwmHP/SWWUE0JgHgR7EeL8V/qWJJE6BJ6w==", null, false, null, false, "Anonymous" },
                    { new Guid("3cb9148d-41b6-4a5a-920a-b615b5d57945"), 0, "dde334cc-1dc1-42c9-9746-9d9db6b05382", "bob@email.com", false, false, null, "BOB@EMAIL.COM", "BOB", "AQAAAAEAACcQAAAAEMMLygdHnWigq0edcCy9ZooJIaaSLaRcoKZl0+5Z1o9toVrnAtRG+HcZShMqwAVTTQ==", null, false, null, false, "Bob" },
                    { new Guid("06fba9ff-1503-4682-a1a9-52e28f4b84db"), 0, "a948066f-9d4f-40f7-8090-b9708d9964e0", "alice@email.com", false, false, null, "ALICE@EMAIL.COM", "ALICE", "AQAAAAEAACcQAAAAEKcPq1ULmh0OhNfkGI3M6BDqzN2Ek02mBkArz1aDAmsacZK2z4aqUjCa76cEMVQRrQ==", null, false, null, false, "Alice" }
                });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 0, 49, 419, DateTimeKind.Local).AddTicks(5527), new Guid("67d010c7-4e58-42c6-96b6-208d04a7aed0") });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 0, 49, 421, DateTimeKind.Local).AddTicks(6472), new Guid("6c46bcd8-d0be-4142-a837-a9a2ec20d832") });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 0, 49, 421, DateTimeKind.Local).AddTicks(6495), new Guid("1b69e3eb-c8d8-4d90-9070-044cc128aab0") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4c5c70db-ebfb-4ed1-8122-92a5e60a1931"), new Guid("f69eb10a-d216-47de-9c87-f44591f0aa48") },
                    { new Guid("4fc27e2c-2c2e-44ef-8703-766417390eb4"), new Guid("800e8351-91d2-47c0-b91f-c60a2b073e0f") },
                    { new Guid("16732416-1be8-46f0-a30c-4ba2d6261855"), new Guid("3cb9148d-41b6-4a5a-920a-b615b5d57945") },
                    { new Guid("16732416-1be8-46f0-a30c-4ba2d6261855"), new Guid("06fba9ff-1503-4682-a1a9-52e28f4b84db") }
                });

            migrationBuilder.InsertData(
                table: "ChatGroupUsers",
                columns: new[] { "ChatGroupId", "UserId", "CreatedOn", "Uuid" },
                values: new object[,]
                {
                    { 1L, new Guid("f69eb10a-d216-47de-9c87-f44591f0aa48"), new DateTime(2021, 1, 16, 18, 0, 49, 422, DateTimeKind.Local).AddTicks(1109), new Guid("dd1478cb-ab37-4980-8446-472767daed7b") },
                    { 1L, new Guid("800e8351-91d2-47c0-b91f-c60a2b073e0f"), new DateTime(2021, 1, 16, 18, 0, 49, 422, DateTimeKind.Local).AddTicks(1861), new Guid("95e491c1-0b62-43a4-bbd6-dce225f704b3") },
                    { 1L, new Guid("3cb9148d-41b6-4a5a-920a-b615b5d57945"), new DateTime(2021, 1, 16, 18, 0, 49, 422, DateTimeKind.Local).AddTicks(1881), new Guid("86375d36-de9d-4360-a574-c1f6e19fd00d") },
                    { 1L, new Guid("06fba9ff-1503-4682-a1a9-52e28f4b84db"), new DateTime(2021, 1, 16, 18, 0, 49, 422, DateTimeKind.Local).AddTicks(1884), new Guid("fa922160-b167-437e-add9-0b2c746add8c") }
                });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "UserId", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 0, 49, 421, DateTimeKind.Local).AddTicks(8097), new Guid("f69eb10a-d216-47de-9c87-f44591f0aa48"), new Guid("313c1f03-2a9d-4b1e-870f-924b027b8900") });

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "UserId", "Uuid" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 0, 49, 421, DateTimeKind.Local).AddTicks(9717), new Guid("800e8351-91d2-47c0-b91f-c60a2b073e0f"), new Guid("a0f101ae-46b7-451c-b6d0-fdb5a1712a34") });
        }
    }
}
