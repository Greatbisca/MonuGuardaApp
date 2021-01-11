using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class VisitasGuiadasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropForeignKey(
                name: "FK_VisitasGuiadas_PontosdeInteresse_PontosdeInteresseId",
                table: "VisitasGuiadas");

            migrationBuilder.DropIndex(
                name: "IX_VisitasGuiadas_PontosdeInteresseId",
                table: "VisitasGuiadas");
           */
            migrationBuilder.DropColumn(
                name: "DataVisita",
                table: "VisitasGuiadas");

            migrationBuilder.DropColumn(
                name: "LocalChegada",
                table: "VisitasGuiadas");

            migrationBuilder.DropColumn(
                name: "LocalPartida",
                table: "VisitasGuiadas");

            migrationBuilder.DropColumn(
                name: "PontosdeInteresseId",
                table: "VisitasGuiadas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatadaVisita",
                table: "VisitasGuiadas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LocaldeChegada",
                table: "VisitasGuiadas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocaldePartida",
                table: "VisitasGuiadas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatadaVisita",
                table: "VisitasGuiadas");

            migrationBuilder.DropColumn(
                name: "LocaldeChegada",
                table: "VisitasGuiadas");

            migrationBuilder.DropColumn(
                name: "LocaldePartida",
                table: "VisitasGuiadas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVisita",
                table: "VisitasGuiadas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LocalChegada",
                table: "VisitasGuiadas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocalPartida",
                table: "VisitasGuiadas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PontosdeInteresseId",
                table: "VisitasGuiadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VisitasGuiadas_PontosdeInteresseId",
                table: "VisitasGuiadas",
                column: "PontosdeInteresseId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitasGuiadas_PontosdeInteresse_PontosdeInteresseId",
                table: "VisitasGuiadas",
                column: "PontosdeInteresseId",
                principalTable: "PontosdeInteresse",
                principalColumn: "PontosdeInteresseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
