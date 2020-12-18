using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class TuristasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataReserva",
                table: "ReservaVisita",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVisita_TuristaId",
                table: "ReservaVisita",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVisita_VisitasGuiadasId",
                table: "ReservaVisita",
                column: "VisitasGuiadasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaVisita_Turista_TuristaId",
                table: "ReservaVisita",
                column: "TuristaId",
                principalTable: "Turista",
                principalColumn: "TuristaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaVisita_VisitasGuiadas_VisitasGuiadasId",
                table: "ReservaVisita",
                column: "VisitasGuiadasId",
                principalTable: "VisitasGuiadas",
                principalColumn: "VisitasGuiadasId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaVisita_Turista_TuristaId",
                table: "ReservaVisita");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaVisita_VisitasGuiadas_VisitasGuiadasId",
                table: "ReservaVisita");

            migrationBuilder.DropIndex(
                name: "IX_ReservaVisita_TuristaId",
                table: "ReservaVisita");

            migrationBuilder.DropIndex(
                name: "IX_ReservaVisita_VisitasGuiadasId",
                table: "ReservaVisita");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DataReserva",
                table: "ReservaVisita",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
