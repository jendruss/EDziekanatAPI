using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDziekanat.EntityFramework.Migrations
{
    public partial class RenameEmployeesToUsersInDeansOfficesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"),
                column: "ConcurrencyStamp",
                value: "995cb981-553c-47f9-9836-d3b3abae3941");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb"),
                column: "ConcurrencyStamp",
                value: "d324a421-f698-47e0-ae28-0ceb238f67cc");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                column: "ConcurrencyStamp",
                value: "20fbb458-d6d3-4096-8eaa-88e80da23666");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"),
                column: "ConcurrencyStamp",
                value: "2efda121-3d39-4e6c-b096-02be1d7ae66c");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"),
                column: "ConcurrencyStamp",
                value: "5efd354f-09d4-45ff-bcfc-0f39f6b9844c");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName" },
                values: new object[] { "1c8d2ef4-4003-4fd2-b23b-87cc8b88b5cb", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"),
                column: "ConcurrencyStamp",
                value: "77c9bc57-b90e-4571-8007-e7f9359e1696");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb"),
                column: "ConcurrencyStamp",
                value: "164c2ac2-48ae-477c-becd-98d00321be5a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                column: "ConcurrencyStamp",
                value: "68fab63d-8d06-4cd7-b9aa-7ad00e68f4a7");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"),
                column: "ConcurrencyStamp",
                value: "6cf1b4a8-cd8f-4940-a529-6a2837f5ad97");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"),
                column: "ConcurrencyStamp",
                value: "aa0bcd09-0ce0-4dd2-b3cb-e21d7877303c");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName" },
                values: new object[] { "e0227662-5819-45c1-9acd-40043677e325", null, null });
        }
    }
}
