using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_01.Migrations.Tablica
{
    public partial class Vrsta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vrsta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoId = table.Column<int>(nullable: true),
                    MotoriId = table.Column<int>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    TipVozila = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vrsta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vrsta_Auto_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Auto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vrsta_Motori_MotoriId",
                        column: x => x.MotoriId,
                        principalTable: "Motori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vrsta_AutoId",
                table: "Vrsta",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vrsta_MotoriId",
                table: "Vrsta",
                column: "MotoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vrsta");
        }
    }
}
