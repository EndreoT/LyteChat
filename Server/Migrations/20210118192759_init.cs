using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LyteChat.Server.Migrations
{
    public partial class init : Migration
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
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    { new Guid("659cad2c-f491-4a57-bcba-bec21345b2b9"), "f29a82d8-b707-4e41-9012-84726d7bb6ec", "Admin", "ADMIN" },
                    { new Guid("29369904-f3a0-4d0f-b9e6-4f177d9e8f41"), "f8c44720-275f-4b07-8262-dff687105542", "AnonymousUser", "ANONYMOUSUSER" },
                    { new Guid("d3417a26-4bc9-49bb-ac10-294a2f7e0125"), "cc9a0941-1d2c-4302-9b1e-9ba2856a9cc6", "AuthenticatedUser", "AUTHENTICATEDUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("38d0925d-10be-4120-a4c0-f4162f01a108"), 0, "8b8cc487-d626-4025-85a1-3dbd0ebaa7d9", "admin@email.com", false, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPMPZQYAh9oMX8Wm3DLxCQZ9EFVk33FI/b64bWgtAzitPDv4FinSUd7srr+kLL7gnA==", null, false, null, false, "Admin" },
                    { new Guid("b16625c6-ad67-4510-88f1-a63b1f614129"), 0, "5a0862a8-9110-45b9-9fa4-ce6bb293d6bf", "anonymous@email.com", false, false, null, "ANONYMOUS@EMAIL.COM", "ANONYMOUS", "AQAAAAEAACcQAAAAEAn+UX8+DdT2cSlw3z0p6tf29qIx0k7is5F64EQ1lqepjmTO4sfWzfCgJpKL8Y/Ymg==", null, false, null, false, "Anonymous" },
                    { new Guid("10560706-69e6-47ad-b67a-9b20b59fc903"), 0, "b4ed3079-bd4c-43b9-92ec-a03d5640cce0", "bob@email.com", false, false, null, "BOB@EMAIL.COM", "BOB", "AQAAAAEAACcQAAAAEMfynyy2sQuUZXH2CvVQ8sAkBOwVix0ai/poe45yipSmGj2tgHHfuZScEG5mQx2TyQ==", null, false, null, false, "Bob" },
                    { new Guid("0d7ed384-a659-4981-96ba-dddf04ae4917"), 0, "a3f9f538-e751-405a-811d-5327db03251e", "alice@email.com", false, false, null, "ALICE@EMAIL.COM", "ALICE", "AQAAAAEAACcQAAAAEFZPrvESj7TqTJ1xH4S6h2AA7K0Hda0LE73w8p6jvVvq4Indq/BAZMskRDmo3YLOKQ==", null, false, null, false, "Alice" }
                });

            migrationBuilder.InsertData(
                table: "ChatGroups",
                columns: new[] { "ChatGroupId", "ChatGroupName", "CreatedOn", "Uuid" },
                values: new object[,]
                {
                    { 1L, "All Chat", new DateTime(2021, 1, 18, 11, 27, 58, 593, DateTimeKind.Local).AddTicks(3674), new Guid("9a9f7169-e7c3-42d7-9eb2-d95ffddff45c") },
                    { 2L, "second chat group", new DateTime(2021, 1, 18, 11, 27, 58, 595, DateTimeKind.Local).AddTicks(5574), new Guid("d4d4f5aa-e176-4030-84f3-4b86dd5bb6c4") },
                    { 3L, "third chat group", new DateTime(2021, 1, 18, 11, 27, 58, 595, DateTimeKind.Local).AddTicks(5600), new Guid("ad43fcc0-1f63-4a74-98cb-654e2ecc99b0") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("659cad2c-f491-4a57-bcba-bec21345b2b9"), new Guid("38d0925d-10be-4120-a4c0-f4162f01a108") },
                    { new Guid("29369904-f3a0-4d0f-b9e6-4f177d9e8f41"), new Guid("b16625c6-ad67-4510-88f1-a63b1f614129") },
                    { new Guid("d3417a26-4bc9-49bb-ac10-294a2f7e0125"), new Guid("10560706-69e6-47ad-b67a-9b20b59fc903") },
                    { new Guid("d3417a26-4bc9-49bb-ac10-294a2f7e0125"), new Guid("0d7ed384-a659-4981-96ba-dddf04ae4917") }
                });

            migrationBuilder.InsertData(
                table: "ChatGroupUsers",
                columns: new[] { "ChatGroupId", "UserId", "CreatedOn", "Uuid" },
                values: new object[,]
                {
                    { 1L, new Guid("38d0925d-10be-4120-a4c0-f4162f01a108"), new DateTime(2021, 1, 18, 11, 27, 58, 596, DateTimeKind.Local).AddTicks(539), new Guid("c7bd537b-af58-419e-a4f2-5142f2b0d22d") },
                    { 1L, new Guid("b16625c6-ad67-4510-88f1-a63b1f614129"), new DateTime(2021, 1, 18, 11, 27, 58, 596, DateTimeKind.Local).AddTicks(1362), new Guid("1dfc2670-4138-4219-904b-228f02a5ec77") },
                    { 1L, new Guid("10560706-69e6-47ad-b67a-9b20b59fc903"), new DateTime(2021, 1, 18, 11, 27, 58, 596, DateTimeKind.Local).AddTicks(1381), new Guid("8aa8598a-e74b-4fb5-8200-3bcdb067f0a2") },
                    { 1L, new Guid("0d7ed384-a659-4981-96ba-dddf04ae4917"), new DateTime(2021, 1, 18, 11, 27, 58, 596, DateTimeKind.Local).AddTicks(1384), new Guid("72603de7-8fcc-4d85-9c7d-0e7e78a293b2") }
                });

            migrationBuilder.InsertData(
                table: "ChatMessages",
                columns: new[] { "ChatMessageId", "ChatGroupId", "CreatedOn", "Message", "UserId", "Uuid" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 1, 18, 11, 27, 58, 595, DateTimeKind.Local).AddTicks(7239), "first message", new Guid("38d0925d-10be-4120-a4c0-f4162f01a108"), new Guid("bb53afec-ecf0-4b6a-b56a-c9c6ca6b8b85") },
                    { 2L, 2L, new DateTime(2021, 1, 18, 11, 27, 58, 595, DateTimeKind.Local).AddTicks(8953), "second message", new Guid("b16625c6-ad67-4510-88f1-a63b1f614129"), new Guid("43799d6a-2ad8-4f33-95db-60aae054bdf5") }
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
