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
                    Telemovel = table.Column<int>(nullable: false)
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
                    Tipo = table.Column<string>(nullable: true),
                    Freguesia = table.Column<string>(nullable: true),
                    Concelho = table.Column<string>(nullable: true),
                    EstatutoPatrimonial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosdeInteresse", x => x.PontosdeInteresseId);
                });

            migrationBuilder.CreateTable(
                name: "ReservaVisita",
                columns: table => new
                {
                    ReservaVisitaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuristaId = table.Column<int>(nullable: false),
                    VisitasGuiadasId = table.Column<int>(nullable: false),
                    DataReserva = table.Column<DateTimeOffset>(nullable: false),
                    NPessoas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaVisita", x => x.ReservaVisitaId);
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
                    PontosdeInteresseId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    LocalPartida = table.Column<string>(nullable: false),
                    LocalChegada = table.Column<string>(nullable: false),
                    DataVisita = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    NMaxPessoas = table.Column<int>(nullable: false),
                    Completo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasGuiadas", x => x.VisitasGuiadasId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guia");

            migrationBuilder.DropTable(
                name: "PontosdeInteresse");

            migrationBuilder.DropTable(
                name: "ReservaVisita");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropTable(
                name: "VisitasGuiadas");
        }
    }
}
