using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class AddPassordtoTurista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Turista",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Turista");

        }
    }
}
