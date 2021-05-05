using Microsoft.EntityFrameworkCore.Migrations;

namespace ToolSmukfest.Migrations
{
    public partial class member : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembaOrders_Teams_TeamId",
                table: "MembaOrders");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "MembaOrders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "MembaOrders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByMemberId",
                table: "MembaOrders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MembaOrders_Teams_TeamId",
                table: "MembaOrders",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembaOrders_Teams_TeamId",
                table: "MembaOrders");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "MembaOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "MembaOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByMemberId",
                table: "MembaOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MembaOrders_Teams_TeamId",
                table: "MembaOrders",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
