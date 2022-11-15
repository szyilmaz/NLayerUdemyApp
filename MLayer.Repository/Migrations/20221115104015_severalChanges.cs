using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class severalChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipi",
                table: "Hareketler");

            migrationBuilder.AddColumn<int>(
                name: "MusteriTipi",
                table: "Musteriler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DovizTipiId",
                table: "Hesaplar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HesapTipiId",
                table: "Hesaplar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HareketTipiId",
                table: "Hareketler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DovizTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DovizTipleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HareketTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HareketTipleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HesapTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapTipleri", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_DovizTipiId",
                table: "Hesaplar",
                column: "DovizTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_HesapTipiId",
                table: "Hesaplar",
                column: "HesapTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_HareketTipiId",
                table: "Hareketler",
                column: "HareketTipiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hareketler_HareketTipleri_HareketTipiId",
                table: "Hareketler",
                column: "HareketTipiId",
                principalTable: "HareketTipleri",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_DovizTipleri_DovizTipiId",
                table: "Hesaplar",
                column: "DovizTipiId",
                principalTable: "DovizTipleri",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_HesapTipleri_HesapTipiId",
                table: "Hesaplar",
                column: "HesapTipiId",
                principalTable: "HesapTipleri",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hareketler_HareketTipleri_HareketTipiId",
                table: "Hareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_DovizTipleri_DovizTipiId",
                table: "Hesaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_HesapTipleri_HesapTipiId",
                table: "Hesaplar");

            migrationBuilder.DropTable(
                name: "DovizTipleri");

            migrationBuilder.DropTable(
                name: "HareketTipleri");

            migrationBuilder.DropTable(
                name: "HesapTipleri");

            migrationBuilder.DropIndex(
                name: "IX_Hesaplar_DovizTipiId",
                table: "Hesaplar");

            migrationBuilder.DropIndex(
                name: "IX_Hesaplar_HesapTipiId",
                table: "Hesaplar");

            migrationBuilder.DropIndex(
                name: "IX_Hareketler_HareketTipiId",
                table: "Hareketler");

            migrationBuilder.DropColumn(
                name: "MusteriTipi",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "DovizTipiId",
                table: "Hesaplar");

            migrationBuilder.DropColumn(
                name: "HesapTipiId",
                table: "Hesaplar");

            migrationBuilder.DropColumn(
                name: "HareketTipiId",
                table: "Hareketler");

            migrationBuilder.AddColumn<int>(
                name: "Tipi",
                table: "Hareketler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
