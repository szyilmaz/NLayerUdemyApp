using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class xxx2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "HesapHesapTipleri",
                columns: table => new
                {
                    HesapTipleriId = table.Column<int>(type: "int", nullable: false),
                    HesaplarId = table.Column<int>(type: "int", nullable: false),
                    HesapTipiId = table.Column<int>(type: "int", nullable: true),
                    HesapId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapHesapTipleri", x => new { x.HesaplarId, x.HesapTipleriId });
                    table.ForeignKey(
                        name: "FK_HesapHesapTipleri_Hesaplar_HesapId",
                        column: x => x.HesapId,
                        principalTable: "Hesaplar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HesapHesapTipleri_HesapTipleri_HesapTipiId",
                        column: x => x.HesapTipiId,
                        principalTable: "HesapTipleri",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HesapHesapTipleri_HesapId",
                table: "HesapHesapTipleri",
                column: "HesapId");

            migrationBuilder.CreateIndex(
                name: "IX_HesapHesapTipleri_HesapTipiId",
                table: "HesapHesapTipleri",
                column: "HesapTipiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HesapHesapTipleri");

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
    }
}
