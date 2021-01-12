using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class VisitasGuiadasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocaldeChegada",
                table: "VisitasGuiadas");

            migrationBuilder.DropColumn(
                name: "LocaldePartida",
                table: "VisitasGuiadas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocaldeChegada",
                table: "VisitasGuiadas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocaldePartida",
                table: "VisitasGuiadas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
