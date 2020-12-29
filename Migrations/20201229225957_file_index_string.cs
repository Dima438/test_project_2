using Microsoft.EntityFrameworkCore.Migrations;

namespace db_stuff.Migrations
{
    public partial class file_index_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdString",
                table: "Records",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdString",
                table: "Records");
        }
    }
}
