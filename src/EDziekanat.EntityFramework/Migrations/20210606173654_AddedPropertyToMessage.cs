using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDziekanat.EntityFramework.Migrations
{
    public partial class AddedPropertyToMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Messages",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"),
                column: "ConcurrencyStamp",
                value: "4e997d9f-eb2a-44c5-bb37-610aaac56b54");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb"),
                column: "ConcurrencyStamp",
                value: "ceabdda9-5d65-4c13-a513-5a048012d6d4");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                column: "ConcurrencyStamp",
                value: "f713ebbd-b53d-4f80-bc76-61aa093b1cb7");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"),
                column: "ConcurrencyStamp",
                value: "29d65c5a-5cb2-461a-a071-d10f0d0e8158");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"),
                column: "ConcurrencyStamp",
                value: "d31724c0-f639-4dc8-8f0d-6908ac0160e6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"),
                column: "ConcurrencyStamp",
                value: "043e6a99-b5bc-4906-984a-86cbf53d31b0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"),
                column: "ConcurrencyStamp",
                value: "16c56c41-88a1-49e6-85de-29cc820ea96a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb"),
                column: "ConcurrencyStamp",
                value: "fd987e14-bc32-4648-b369-93ecf2cae3d2");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                column: "ConcurrencyStamp",
                value: "486d543b-d30f-4722-986f-849e3a363b4c");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"),
                column: "ConcurrencyStamp",
                value: "7e5a4730-59b0-49ee-b99d-7d388bed9d2a");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"),
                column: "ConcurrencyStamp",
                value: "32125aea-316b-4b10-a3c9-9d11055de452");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"),
                column: "ConcurrencyStamp",
                value: "efc12cd1-2d2f-45c9-bd08-f5f7a1c59723");
        }
    }
}
