using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolSmukfest.Migrations
{
    public partial class section : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembaOrders_Section_SectionId",
                table: "MembaOrders");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "MembaOrders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MembaOrders_Section_SectionId",
                table: "MembaOrders",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembaOrders_Section_SectionId",
                table: "MembaOrders");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "MembaOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MembaOrders_Section_SectionId",
                table: "MembaOrders",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
