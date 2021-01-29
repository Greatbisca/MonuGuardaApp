using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class GuiaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaVisita",
                table: "ReservaVisita");

            migrationBuilder.DropIndex(
                name: "IX_ReservaVisita_VisitasGuiadasId",
                table: "ReservaVisita");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Guia",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaVisita",
                table: "ReservaVisita",
                column: "VisitasGuiadasId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaVisita_VisitasGuiadas_VisitasGuiadasId",
                table: "ReservaVisita");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaVisita",
                table: "ReservaVisita");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Guia");

            migrationBuilder.AlterColumn<int>(
                name: "ReservaVisitaId",
                table: "ReservaVisita",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaVisita",
                table: "ReservaVisita",
                column: "ReservaVisitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVisita_VisitasGuiadasId",
                table: "ReservaVisita",
                column: "VisitasGuiadasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaVisita_VisitasGuiadas_VisitasGuiadasId",
                table: "ReservaVisita",
                column: "VisitasGuiadasId",
                principalTable: "VisitasGuiadas",
                principalColumn: "VisitasGuiadasId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
