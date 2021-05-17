using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDziekanat.EntityFramework.Migrations
{
    public partial class AddedOperationNameToReservationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OperationName",
                table: "Reservations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"),
                column: "ConcurrencyStamp",
                value: "81ecbdeb-cbe9-4838-a661-92246ef0b9de");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb"),
                column: "ConcurrencyStamp",
                value: "54815835-8a43-4185-a1c1-e17704a4c46c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                column: "ConcurrencyStamp",
                value: "76cea737-1a12-47d9-afc5-2014078e5d7f");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"),
                column: "ConcurrencyStamp",
                value: "9109130f-a7de-4251-b81b-771f8ad06b7f");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"),
                column: "ConcurrencyStamp",
                value: "c8505de0-79ed-4cbb-9081-646be9b53ff0");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"),
                column: "ConcurrencyStamp",
                value: "e1f68001-d533-47e2-b27c-f0db117501f1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationName",
                table: "Reservations");

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
                column: "ConcurrencyStamp",
                value: "1c8d2ef4-4003-4fd2-b23b-87cc8b88b5cb");
        }
    }
}
