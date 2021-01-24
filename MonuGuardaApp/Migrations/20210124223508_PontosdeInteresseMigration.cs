using Microsoft.EntityFrameworkCore.Migrations;

namespace MonuGuardaApp.Migrations
{
    public partial class PontosdeInteresseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concelho",
                table: "PontosdeInteresse");

            migrationBuilder.DropColumn(
                name: "Freguesia",
                table: "PontosdeInteresse");

            migrationBuilder.AddColumn<int>(
                name: "ConcelhoId",
                table: "PontosdeInteresse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreguesiaId",
                table: "PontosdeInteresse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Concelho",
                columns: table => new
                {
                    ConcelhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concelho", x => x.ConcelhoId);
                });

            migrationBuilder.CreateTable(
                name: "Freguesia",
                columns: table => new
                {
                    FreguesiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freguesia", x => x.FreguesiaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontosdeInteresse_ConcelhoId",
                table: "PontosdeInteresse",
                column: "ConcelhoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosdeInteresse_FreguesiaId",
                table: "PontosdeInteresse",
                column: "FreguesiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosdeInteresse_Concelho_ConcelhoId",
                table: "PontosdeInteresse",
                column: "ConcelhoId",
                principalTable: "Concelho",
                principalColumn: "ConcelhoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosdeInteresse_Freguesia_FreguesiaId",
                table: "PontosdeInteresse",
                column: "FreguesiaId",
                principalTable: "Freguesia",
                principalColumn: "FreguesiaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosdeInteresse_Concelho_ConcelhoId",
                table: "PontosdeInteresse");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosdeInteresse_Freguesia_FreguesiaId",
                table: "PontosdeInteresse");

            migrationBuilder.DropTable(
                name: "Concelho");

            migrationBuilder.DropTable(
                name: "Freguesia");

            migrationBuilder.DropIndex(
                name: "IX_PontosdeInteresse_ConcelhoId",
                table: "PontosdeInteresse");

            migrationBuilder.DropIndex(
                name: "IX_PontosdeInteresse_FreguesiaId",
                table: "PontosdeInteresse");

            migrationBuilder.DropColumn(
                name: "ConcelhoId",
                table: "PontosdeInteresse");

            migrationBuilder.DropColumn(
                name: "FreguesiaId",
                table: "PontosdeInteresse");

            migrationBuilder.AddColumn<string>(
                name: "Concelho",
                table: "PontosdeInteresse",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Freguesia",
                table: "PontosdeInteresse",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}
