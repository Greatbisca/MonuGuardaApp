using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class VisitasGuiadasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VisitasGuiadas_GuiaId",
                table: "VisitasGuiadas",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasGuiadas_PontosdeInteresseId",
                table: "VisitasGuiadas",
                column: "PontosdeInteresseId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitasGuiadas_Guia_GuiaId",
                table: "VisitasGuiadas",
                column: "GuiaId",
                principalTable: "Guia",
                principalColumn: "GuiaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitasGuiadas_PontosdeInteresse_PontosdeInteresseId",
                table: "VisitasGuiadas",
                column: "PontosdeInteresseId",
                principalTable: "PontosdeInteresse",
                principalColumn: "PontosdeInteresseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitasGuiadas_Guia_GuiaId",
                table: "VisitasGuiadas");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitasGuiadas_PontosdeInteresse_PontosdeInteresseId",
                table: "VisitasGuiadas");

            migrationBuilder.DropIndex(
                name: "IX_VisitasGuiadas_GuiaId",
                table: "VisitasGuiadas");

            migrationBuilder.DropIndex(
                name: "IX_VisitasGuiadas_PontosdeInteresseId",
                table: "VisitasGuiadas");
        }
    }
}
