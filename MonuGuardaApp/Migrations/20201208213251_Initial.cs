using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
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
                    table.PrimaryKey("PK_Customers", x => x.TuristaId);
                });

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
                name: "Rotas",
                columns: table => new
                {
                    VisitasGuiadasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuiaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    LocalPartida = table.Column<string>(nullable: true),
                    LocalChegada = table.Column<string>(nullable: true),
                    DataVisita = table.Column<DateTimeOffset>(nullable: false),
                    Morada = table.Column<string>(nullable: true),
                    Telemovel = table.Column<int>(nullable: false),
                    NMaxPessoas = table.Column<int>(nullable: false),
                    Completo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.VisitasGuiadasId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Guia");

            migrationBuilder.DropTable(
                name: "ReservaVisita");

            migrationBuilder.DropTable(
                name: "Rotas");
        }
    }
}
