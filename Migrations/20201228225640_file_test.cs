using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace db_stuff.Migrations
{
    public partial class file_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Records");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "Files");

            migrationBuilder.RenameColumn(
                name: "aString",
                table: "Files",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "aNumber",
                table: "Files",
                newName: "Id");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Files",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "Tests");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tests",
                newName: "aString");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tests",
                newName: "aNumber");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Records",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "aNumber");
        }
    }
}
