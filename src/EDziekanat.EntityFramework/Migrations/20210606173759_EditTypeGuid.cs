using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDziekanat.EntityFramework.Migrations
{
    public partial class EditTypeGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"),
                column: "ConcurrencyStamp",
                value: "f1705d7c-a9a7-425b-b6fd-9334abee3c8c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb"),
                column: "ConcurrencyStamp",
                value: "77c609c5-b254-4668-b381-81af224d821b");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                column: "ConcurrencyStamp",
                value: "9f235626-8bce-4acf-b8a1-58b845f38145");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"),
                column: "ConcurrencyStamp",
                value: "2ab87676-c5ab-4bda-812a-3ca6ce021239");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"),
                column: "ConcurrencyStamp",
                value: "811cff7d-a816-4358-a661-4b40606fd7b1");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"),
                column: "ConcurrencyStamp",
                value: "e350aad9-fa6f-4b03-8b9e-0a6d4457e8d7");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

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
    }
}
