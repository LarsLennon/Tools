using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolSmukfest.Migrations
{
    public partial class MembaTextMac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MembaTextMatch",
                table: "ItemType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembaTextMatch",
                table: "ItemType");
        }
    }
}
