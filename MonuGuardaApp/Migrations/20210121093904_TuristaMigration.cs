using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class TuristaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaVisita_Turista_TuristaId",
                table: "ReservaVisita");

            migrationBuilder.AlterColumn<int>(
                name: "TuristaId",
                table: "ReservaVisita",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaVisita_Turista_TuristaId",
                table: "ReservaVisita",
                column: "TuristaId",
                principalTable: "Turista",
                principalColumn: "TuristaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaVisita_Turista_TuristaId",
                table: "ReservaVisita");

            migrationBuilder.AlterColumn<int>(
                name: "TuristaId",
                table: "ReservaVisita",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaVisita_Turista_TuristaId",
                table: "ReservaVisita",
                column: "TuristaId",
                principalTable: "Turista",
                principalColumn: "TuristaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
