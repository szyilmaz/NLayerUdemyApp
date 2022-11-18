using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class xxx1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HesapHesapTipi");

            migrationBuilder.AddColumn<int>(
                name: "HesapId",
                table: "HesapTipleri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HesapTipleri_HesapId",
                table: "HesapTipleri",
                column: "HesapId");

            migrationBuilder.AddForeignKey(
                name: "FK_HesapTipleri_Hesaplar_HesapId",
                table: "HesapTipleri",
                column: "HesapId",
                principalTable: "Hesaplar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HesapTipleri_Hesaplar_HesapId",
                table: "HesapTipleri");

            migrationBuilder.DropIndex(
                name: "IX_HesapTipleri_HesapId",
                table: "HesapTipleri");

            migrationBuilder.DropColumn(
                name: "HesapId",
                table: "HesapTipleri");

            migrationBuilder.CreateTable(
                name: "HesapHesapTipi",
                columns: table => new
                {
                    HesapTipleriId = table.Column<int>(type: "int", nullable: false),
                    HesaplarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapHesapTipi", x => new { x.HesapTipleriId, x.HesaplarId });
                    table.ForeignKey(
                        name: "FK_HesapHesapTipi_Hesaplar_HesaplarId",
                        column: x => x.HesaplarId,
                        principalTable: "Hesaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HesapHesapTipi_HesapTipleri_HesapTipleriId",
                        column: x => x.HesapTipleriId,
                        principalTable: "HesapTipleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HesapHesapTipi_HesaplarId",
                table: "HesapHesapTipi",
                column: "HesaplarId");
        }
    }
}
