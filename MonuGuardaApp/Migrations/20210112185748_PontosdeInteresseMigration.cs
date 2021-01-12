using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class PontosdeInteresseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstatutoPatrimonial",
                table: "PontosdeInteresse");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "PontosdeInteresse");

            migrationBuilder.AddColumn<string>(
                name: "Coordenadas",
                table: "PontosdeInteresse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "PontosdeInteresse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordenadas",
                table: "PontosdeInteresse");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "PontosdeInteresse");

            migrationBuilder.AddColumn<string>(
                name: "EstatutoPatrimonial",
                table: "PontosdeInteresse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "PontosdeInteresse",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
