using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hareketler_HareketTipleri_HareketTipiId",
                table: "Hareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_Hareketler_Hesaplar_HesapId",
                table: "Hareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_DovizTipleri_DovizTipiId",
                table: "Hesaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_Musteriler_MusteriId",
                table: "Hesaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_Subeler_SubeId",
                table: "Hesaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_Bankalar_BankaId",
                table: "Subeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_Lokasyonlar_LokasyonId",
                table: "Subeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_SubeTipleri_SubeTipiId",
                table: "Subeler");

            migrationBuilder.AlterColumn<int>(
                name: "SubeTipiId",
                table: "Subeler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LokasyonId",
                table: "Subeler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankaId",
                table: "Subeler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubeId",
                table: "Hesaplar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MusteriId",
                table: "Hesaplar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DovizTipiId",
                table: "Hesaplar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HesapId",
                table: "Hareketler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HareketTipiId",
                table: "Hareketler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hareketler_HareketTipleri_HareketTipiId",
                table: "Hareketler",
                column: "HareketTipiId",
                principalTable: "HareketTipleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hareketler_Hesaplar_HesapId",
                table: "Hareketler",
                column: "HesapId",
                principalTable: "Hesaplar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_DovizTipleri_DovizTipiId",
                table: "Hesaplar",
                column: "DovizTipiId",
                principalTable: "DovizTipleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_Musteriler_MusteriId",
                table: "Hesaplar",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_Subeler_SubeId",
                table: "Hesaplar",
                column: "SubeId",
                principalTable: "Subeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_Bankalar_BankaId",
                table: "Subeler",
                column: "BankaId",
                principalTable: "Bankalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_Lokasyonlar_LokasyonId",
                table: "Subeler",
                column: "LokasyonId",
                principalTable: "Lokasyonlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_SubeTipleri_SubeTipiId",
                table: "Subeler",
                column: "SubeTipiId",
                principalTable: "SubeTipleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hareketler_HareketTipleri_HareketTipiId",
                table: "Hareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_Hareketler_Hesaplar_HesapId",
                table: "Hareketler");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_DovizTipleri_DovizTipiId",
                table: "Hesaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_Musteriler_MusteriId",
                table: "Hesaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesaplar_Subeler_SubeId",
                table: "Hesaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_Bankalar_BankaId",
                table: "Subeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_Lokasyonlar_LokasyonId",
                table: "Subeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_SubeTipleri_SubeTipiId",
                table: "Subeler");

            migrationBuilder.AlterColumn<int>(
                name: "SubeTipiId",
                table: "Subeler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LokasyonId",
                table: "Subeler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BankaId",
                table: "Subeler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubeId",
                table: "Hesaplar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MusteriId",
                table: "Hesaplar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DovizTipiId",
                table: "Hesaplar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HesapId",
                table: "Hareketler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HareketTipiId",
                table: "Hareketler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Hareketler_HareketTipleri_HareketTipiId",
                table: "Hareketler",
                column: "HareketTipiId",
                principalTable: "HareketTipleri",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hareketler_Hesaplar_HesapId",
                table: "Hareketler",
                column: "HesapId",
                principalTable: "Hesaplar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_DovizTipleri_DovizTipiId",
                table: "Hesaplar",
                column: "DovizTipiId",
                principalTable: "DovizTipleri",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_Musteriler_MusteriId",
                table: "Hesaplar",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hesaplar_Subeler_SubeId",
                table: "Hesaplar",
                column: "SubeId",
                principalTable: "Subeler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_Bankalar_BankaId",
                table: "Subeler",
                column: "BankaId",
                principalTable: "Bankalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_Lokasyonlar_LokasyonId",
                table: "Subeler",
                column: "LokasyonId",
                principalTable: "Lokasyonlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_SubeTipleri_SubeTipiId",
                table: "Subeler",
                column: "SubeTipiId",
                principalTable: "SubeTipleri",
                principalColumn: "Id");
        }
    }
}
