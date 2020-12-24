using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnBlazor.Server.Migrations
{
    public partial class chatgroupuseraddid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ChatGroupUserId",
                table: "ChatGroupUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, 1L },
                column: "Uuid",
                value: new Guid("fcaf1730-7ea3-45f2-9bb8-2f52f514d446"));

            migrationBuilder.UpdateData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, 1L },
                column: "Uuid",
                value: new Guid("f81384a7-f13e-483c-97b4-4b948df0ce10"));

            migrationBuilder.UpdateData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 3L, 1L },
                column: "Uuid",
                value: new Guid("dce3c3a3-248d-4304-bd1c-c43de212f98e"));

            migrationBuilder.UpdateData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, 2L },
                column: "Uuid",
                value: new Guid("8bc15b99-01ff-4cca-9147-f829cadac86d"));

            migrationBuilder.InsertData(
                table: "ChatGroupUsers",
                columns: new[] { "ChatGroupId", "UserId", "ChatGroupUserId", "Uuid" },
                values: new object[,]
                {
                    { 2L, 2L, 0L, new Guid("7f8f806d-a9c9-4141-a45e-5d72ce4a0932") },
                    { 1L, 3L, 0L, new Guid("03efdf7d-8eac-4210-ba07-743ed934fcbb") }
                });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L,
                columns: new[] { "ChatGroupName", "Uuid" },
                values: new object[] { "All Chat", new Guid("33820d5f-305d-4b96-8907-6fa6dafbdcef") });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("af4b47a5-9699-4e01-9830-f0673c5f6183"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L,
                column: "Uuid",
                value: new Guid("f1e11a77-6874-449e-8ae3-35bf781ee801"));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("a2bc548b-1ed5-42cc-9c82-f2ccc6594743"));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("f0d0f05c-7d31-4d9e-b418-35e685c14cf1"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                columns: new[] { "Name", "Uuid" },
                values: new object[] { "Anonymous", new Guid("748f55c3-3d67-4347-95fa-e97ef33c907d") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("90c63ff5-bc48-4135-8bb0-d8da05b7aa16"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3L,
                columns: new[] { "Name", "Uuid" },
                values: new object[] { "Carson", new Guid("6ea0fe29-2fa7-4cca-bf83-5645f275fc8a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, 3L });

            migrationBuilder.DropColumn(
                name: "ChatGroupUserId",
                table: "ChatGroupUsers");

            migrationBuilder.UpdateData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, 1L },
                column: "Uuid",
                value: new Guid("3f1ac551-d124-4415-8f46-c19ab0742c62"));

            migrationBuilder.UpdateData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 2L, 1L },
                column: "Uuid",
                value: new Guid("c4928118-7c7b-42ea-9db0-630e9b811e7f"));

            migrationBuilder.UpdateData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 3L, 1L },
                column: "Uuid",
                value: new Guid("22b511f8-9674-4cd8-9246-0dcb3979cddc"));

            migrationBuilder.UpdateData(
                table: "ChatGroupUsers",
                keyColumns: new[] { "ChatGroupId", "UserId" },
                keyValues: new object[] { 1L, 2L },
                column: "Uuid",
                value: new Guid("a878a7d0-3593-4f84-bd20-3c318fc07a83"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L,
                columns: new[] { "ChatGroupName", "Uuid" },
                values: new object[] { "ALL_CHAT", new Guid("5c1a1888-c7f9-40aa-bbb1-ac4f11ec902f") });

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("2af2ae5d-396c-40a8-ad97-f7e81d5fd6ef"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L,
                column: "Uuid",
                value: new Guid("fa50df81-0158-4fda-9813-ddff9f70ba9e"));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("c1d3e679-91a2-4104-9257-1fff551cd8e8"));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("d6ebf6d5-8c4b-4425-ba46-50aa7edd31b8"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                columns: new[] { "Name", "Uuid" },
                values: new object[] { "Carson", new Guid("da42cf59-b564-40b5-8132-c658461ba2e2") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("f0fa72be-4122-4a29-99a0-c4ec702a36cb"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3L,
                columns: new[] { "Name", "Uuid" },
                values: new object[] { "Anonymous", new Guid("492e1a7c-5863-4561-b2ef-ef3a530420a7") });
        }
    }
}
