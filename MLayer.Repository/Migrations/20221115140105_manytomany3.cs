using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class manytomany3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_HesapTipleri_HesapTipiId",
                table: "Hesaplar");

            migrationBuilder.DropTable(
                name: "MusteriMusteriTipi");

            migrationBuilder.DropTable(
                name: "MusteriTipleri");

            migrationBuilder.DropIndex(
                name: "IX_Hesaplar_HesapTipiId",
                table: "Hesaplar");

            migrationBuilder.DropColumn(
                name: "HesapTipiId",
                table: "Hesaplar");

            migrationBuilder.AddColumn<int>(
                name: "SubeTipiId",
                table: "Subeler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MusteriTipi",
                table: "Musteriler",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "SubeTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubeTipleri", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subeler_SubeTipiId",
                table: "Subeler",
                column: "SubeTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_HesapHesapTipi_HesaplarId",
                table: "HesapHesapTipi",
                column: "HesaplarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_SubeTipleri_SubeTipiId",
                table: "Subeler",
                column: "SubeTipiId",
                principalTable: "SubeTipleri",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_SubeTipleri_SubeTipiId",
                table: "Subeler");

            migrationBuilder.DropTable(
                name: "HesapHesapTipi");

            migrationBuilder.DropTable(
                name: "SubeTipleri");

            migrationBuilder.DropIndex(
                name: "IX_Subeler_SubeTipiId",
                table: "Subeler");

            migrationBuilder.DropColumn(
                name: "SubeTipiId",
                table: "Subeler");

            migrationBuilder.DropColumn(
                name: "MusteriTipi",
                table: "Musteriler");

            migrationBuilder.AddColumn<int>(
                name: "HesapTipiId",
                table: "Hesaplar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MusteriTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriTipleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusteriMusteriTipi",
                columns: table => new
                {
                    MusteriTipleriId = table.Column<int>(type: "int", nullable: false),
                    MusterilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriMusteriTipi", x => new { x.MusteriTipleriId, x.MusterilerId });
                    table.ForeignKey(
                        name: "FK_MusteriMusteriTipi_Musteriler_MusterilerId",
                        column: x => x.MusterilerId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusteriMusteriTipi_MusteriTipleri_MusteriTipleriId",
                        column: x => x.MusteriTipleriId,
                        principalTable: "MusteriTipleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_HesapTipiId",
                table: "Hesaplar",
                column: "HesapTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriMusteriTipi_MusterilerId",
                table: "MusteriMusteriTipi",
                column: "MusterilerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_HesapTipleri_HesapTipiId",
                table: "Hesaplar",
                column: "HesapTipiId",
                principalTable: "HesapTipleri",
                principalColumn: "Id");
        }
    }
}
