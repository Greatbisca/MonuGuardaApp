using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class PontosVisitaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PontosVisita",
                columns: table => new
                {
                    PontosVisitaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PontosdeInteresseId = table.Column<int>(nullable: false),
                    VisitasGuiadasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosVisita", x => x.PontosVisitaId);
                    table.ForeignKey(
                        name: "FK_PontosVisita_PontosdeInteresse_PontosdeInteresseId",
                        column: x => x.PontosdeInteresseId,
                        principalTable: "PontosdeInteresse",
                        principalColumn: "PontosdeInteresseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontosVisita_VisitasGuiadas_VisitasGuiadasId",
                        column: x => x.VisitasGuiadasId,
                        principalTable: "VisitasGuiadas",
                        principalColumn: "VisitasGuiadasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontosVisita_PontosdeInteresseId",
                table: "PontosVisita",
                column: "PontosdeInteresseId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVisita_VisitasGuiadasId",
                table: "PontosVisita",
                column: "VisitasGuiadasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontosVisita");
        }
    }
}
