using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnBlazor.Server.Migrations
{
    public partial class ChatGroupUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Uuid",
                table: "ChatGroupUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                column: "Uuid",
                value: new Guid("5c1a1888-c7f9-40aa-bbb1-ac4f11ec902f"));

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
                column: "Uuid",
                value: new Guid("da42cf59-b564-40b5-8132-c658461ba2e2"));

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
                column: "Uuid",
                value: new Guid("492e1a7c-5863-4561-b2ef-ef3a530420a7"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "ChatGroupUsers");

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("9b6c152f-e800-4445-bbb5-351af51761c2"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("691ff5e7-e22a-4d4b-9e90-bf92c9f68b47"));

            migrationBuilder.UpdateData(
                table: "ChatGroups",
                keyColumn: "ChatGroupId",
                keyValue: 3L,
                column: "Uuid",
                value: new Guid("e92348d3-b2b2-4022-a818-c7d57c167bba"));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("ffd811d8-e1cd-4f97-a39a-aba085234f19"));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "ChatMessageId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("8dd16054-f00f-4e3a-8e33-628da3d5f035"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("b1152381-ead4-48dc-be30-09b8d87cdf62"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "Uuid",
                value: new Guid("f4d4b13f-b32c-4742-99d0-605d8b1d26f6"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3L,
                column: "Uuid",
                value: new Guid("769d1250-f4f3-440d-8888-1c86e8b9d084"));
        }
    }
}
