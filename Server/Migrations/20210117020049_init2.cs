using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LyteChat.Server.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatGroups",
                columns: table => new
                {
                    ChatGroupId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatGroupName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatGroups", x => x.ChatGroupId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatGroupUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatGroupUsers", x => new { x.UserId, x.ChatGroupId });
                    table.ForeignKey(
                        name: "FK_ChatGroupUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatGroupUsers_ChatGroups_ChatGroupId",
                        column: x => x.ChatGroupId,
                        principalTable: "ChatGroups",
                        principalColumn: "ChatGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    ChatMessageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.ChatMessageId);
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatGroups_ChatGroupId",
                        column: x => x.ChatGroupId,
                        principalTable: "ChatGroups",
                        principalColumn: "ChatGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "ChatGroups",
                columns: new[] { "ChatGroupId", "ChatGroupName", "CreatedOn", "Uuid" },
                values: new object[,]
                {
                    { 1L, "All Chat", new DateTime(2021, 1, 16, 18, 0, 49, 419, DateTimeKind.Local).AddTicks(5527), new Guid("67d010c7-4e58-42c6-96b6-208d04a7aed0") },
                    { 2L, "second chat group", new DateTime(2021, 1, 16, 18, 0, 49, 421, DateTimeKind.Local).AddTicks(6472), new Guid("6c46bcd8-d0be-4142-a837-a9a2ec20d832") },
                    { 3L, "third chat group", new DateTime(2021, 1, 16, 18, 0, 49, 421, DateTimeKind.Local).AddTicks(6495), new Guid("1b69e3eb-c8d8-4d90-9070-044cc128aab0") }
                });

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

            migrationBuilder.InsertData(
                table: "ChatMessages",
                columns: new[] { "ChatMessageId", "ChatGroupId", "CreatedOn", "Message", "UserId", "Uuid" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 1, 16, 18, 0, 49, 421, DateTimeKind.Local).AddTicks(8097), "first message", new Guid("f69eb10a-d216-47de-9c87-f44591f0aa48"), new Guid("313c1f03-2a9d-4b1e-870f-924b027b8900") },
                    { 2L, 2L, new DateTime(2021, 1, 16, 18, 0, 49, 421, DateTimeKind.Local).AddTicks(9717), "second message", new Guid("800e8351-91d2-47c0-b91f-c60a2b073e0f"), new Guid("a0f101ae-46b7-451c-b6d0-fdb5a1712a34") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChatGroups_ChatGroupName",
                table: "ChatGroups",
                column: "ChatGroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatGroupUsers_ChatGroupId",
                table: "ChatGroupUsers",
                column: "ChatGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatGroupId",
                table: "ChatMessages",
                column: "ChatGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages",
                column: "UserId");
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
