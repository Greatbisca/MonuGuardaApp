using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MonuGuardaApp.Migrations
{
    public partial class RemoveDeprecatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Customers");
            migrationBuilder.DropTable("Rotas");

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
                   table.PrimaryKey("PK_VisitasGuiadas", x => x.VisitasGuiadasId);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
