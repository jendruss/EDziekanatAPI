using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDziekanat.EntityFramework.Migrations
{
    public partial class RenameStudentToUserInMesssage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_StudentId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_StudentId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Messages",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_StudentId",
                table: "Messages",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_StudentId",
                table: "Messages",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
