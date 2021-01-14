using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guia",
                columns: table => new
                {
                    GuiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Telemovel = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    Morada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guia", x => x.GuiaId);
                });

            migrationBuilder.CreateTable(
                name: "PontosdeInteresse",
                columns: table => new
                {
                    PontosdeInteresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Freguesia = table.Column<string>(nullable: true),
                    Concelho = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    Coordenadas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosdeInteresse", x => x.PontosdeInteresseId);
                });

            migrationBuilder.CreateTable(
                name: "Turista",
                columns: table => new
                {
                    TuristaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Morada = table.Column<string>(nullable: true),
                    NIF = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Telemovel = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turista", x => x.TuristaId);
                });

            migrationBuilder.CreateTable(
                name: "VisitasGuiadas",
                columns: table => new
                {
                    VisitasGuiadasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuiaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    DatadaVisita = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    NMaxPessoas = table.Column<int>(nullable: false),
                    Completo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasGuiadas", x => x.VisitasGuiadasId);
                    table.ForeignKey(
                        name: "FK_VisitasGuiadas_Guia_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guia",
                        principalColumn: "GuiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontosVisita",
                columns: table => new
                {
                    PontosVisitaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PontosdeInteresseId = table.Column<int>(nullable: false),
                    VisitasGuiadasId = table.Column<int>(nullable: false),
                    Ordem = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ReservaVisita",
                columns: table => new
                {
                    ReservaVisitaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuristaId = table.Column<int>(nullable: false),
                    VisitasGuiadasId = table.Column<int>(nullable: false),
                    DataReserva = table.Column<DateTime>(nullable: false),
                    NPessoas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaVisita", x => x.ReservaVisitaId);
                    table.ForeignKey(
                        name: "FK_ReservaVisita_Turista_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turista",
                        principalColumn: "TuristaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaVisita_VisitasGuiadas_VisitasGuiadasId",
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

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVisita_TuristaId",
                table: "ReservaVisita",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVisita_VisitasGuiadasId",
                table: "ReservaVisita",
                column: "VisitasGuiadasId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasGuiadas_GuiaId",
                table: "VisitasGuiadas",
                column: "GuiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontosVisita");

            migrationBuilder.DropTable(
                name: "ReservaVisita");

            migrationBuilder.DropTable(
                name: "PontosdeInteresse");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropTable(
                name: "VisitasGuiadas");

            migrationBuilder.DropTable(
                name: "Guia");
        }
    }
}
