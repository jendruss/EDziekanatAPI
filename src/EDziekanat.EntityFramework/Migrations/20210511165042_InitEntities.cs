using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDziekanat.EntityFramework.Migrations
{
    public partial class InitEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    IsSystemDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeansOffices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeansOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeansOffices_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DeansOfficeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_DeansOffices_DeansOfficeId",
                        column: x => x.DeansOfficeId,
                        principalTable: "DeansOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DeansOfficeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_DeansOffices_DeansOfficeId",
                        column: x => x.DeansOfficeId,
                        principalTable: "DeansOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: false),
                    DeansOfficeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_DeansOffices_DeansOfficeId",
                        column: x => x.DeansOfficeId,
                        principalTable: "DeansOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DeansOfficeId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_DeansOffices_DeansOfficeId",
                        column: x => x.DeansOfficeId,
                        principalTable: "DeansOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { new Guid("2a1ccb43-fa4f-48ce-b601-d3ab4d611b32"), "Administration access", "Permissions_Administration" },
                    { new Guid("28126ffd-51c2-4201-939c-b64e3df43b9d"), "Member access", "Permissions_Member_Access" },
                    { new Guid("86d804bd-d022-49a5-821a-d2240478aac4"), "User read", "Permissions_User_Read" },
                    { new Guid("8f3de3ec-3851-4ba9-887a-2119f18ae744"), "User create", "Permissions_User_Create" },
                    { new Guid("068a0171-a141-4eb2-854c-88e43ef9ab7f"), "User update", "Permissions_User_Update" },
                    { new Guid("70b5c5c3-2267-4f7c-b0f9-7ecc952e04a6"), "User delete", "Permissions_User_Delete" },
                    { new Guid("80562f50-8a7d-4bcd-8971-6d856bbcbb7f"), "Role read", "Permissions_Role_Read" },
                    { new Guid("d4d7c0e3-efcf-4dd2-86e7-17d69fda8c75"), "Role create", "Permissions_Role_Create" },
                    { new Guid("ea003a99-4755-4c19-b126-c5cffbc65088"), "Role update", "Permissions_Role_Update" },
                    { new Guid("8f76de0b-114a-4df8-a93d-cec927d06a3c"), "Role delete", "Permissions_Role_Delete" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "IsSystemDefault", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), "20ca059c-47e8-44d2-820c-e374d4c6a2c3", true, "Admin", "ADMIN" },
                    { new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"), "064c3ccf-6605-420e-9cdf-65d8413986d0", true, "Employee", "EMPLOYEE" },
                    { new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb"), "70eab500-7e8a-406e-b544-47a93963ac1f", true, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DeansOfficeId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"), 5, "3d527fe6-d18c-41ad-ae75-a572ba6701e2", null, "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN", "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", null, false, null, false, "Admin" },
                    { new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"), 5, "7e042b1e-ac3b-4209-951b-2842747a2d85", null, "employee@mail.com", true, false, null, "EMPLOYEE@MAIL.COM", "PRACOWNIK DZIEKANATU", "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", null, false, null, false, "Pracownik dziekanatu" },
                    { new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"), 5, "5b8eeb3b-8a69-42c6-bd79-dc772767d68c", null, "student@mail.com", true, false, null, "STUDENT@MAIL.COM", "STUDENT", "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", null, false, null, false, "Student" }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RoleId", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("2a1ccb43-fa4f-48ce-b601-d3ab4d611b32") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("28126ffd-51c2-4201-939c-b64e3df43b9d") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("86d804bd-d022-49a5-821a-d2240478aac4") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("8f3de3ec-3851-4ba9-887a-2119f18ae744") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("068a0171-a141-4eb2-854c-88e43ef9ab7f") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("70b5c5c3-2267-4f7c-b0f9-7ecc952e04a6") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("80562f50-8a7d-4bcd-8971-6d856bbcbb7f") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("d4d7c0e3-efcf-4dd2-86e7-17d69fda8c75") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("ea003a99-4755-4c19-b126-c5cffbc65088") },
                    { new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"), new Guid("8f76de0b-114a-4df8-a93d-cec927d06a3c") },
                    { new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"), new Guid("28126ffd-51c2-4201-939c-b64e3df43b9d") }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"), new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263") },
                    { new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"), new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce") },
                    { new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"), new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeansOffices_DepartmentId",
                table: "DeansOffices",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DeansOfficeId",
                table: "Messages",
                column: "DeansOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_StudentId",
                table: "Messages",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_DeansOfficeId",
                table: "Operations",
                column: "DeansOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DeansOfficeId",
                table: "Reservations",
                column: "DeansOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DeansOfficeId",
                table: "User",
                column: "DeansOfficeId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DeansOffices");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
