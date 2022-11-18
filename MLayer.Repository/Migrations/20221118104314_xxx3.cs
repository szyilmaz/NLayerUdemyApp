using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class xxx3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HesapHesapTipleri_Hesaplar_HesapId",
                table: "HesapHesapTipleri");

            migrationBuilder.DropForeignKey(
                name: "FK_HesapHesapTipleri_HesapTipleri_HesapTipiId",
                table: "HesapHesapTipleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HesapHesapTipleri",
                table: "HesapHesapTipleri");

            migrationBuilder.DropIndex(
                name: "IX_HesapHesapTipleri_HesapId",
                table: "HesapHesapTipleri");

            migrationBuilder.DropColumn(
                name: "HesaplarId",
                table: "HesapHesapTipleri");

            migrationBuilder.DropColumn(
                name: "HesapTipleriId",
                table: "HesapHesapTipleri");

            migrationBuilder.AlterColumn<int>(
                name: "HesapTipiId",
                table: "HesapHesapTipleri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HesapId",
                table: "HesapHesapTipleri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HesapHesapTipleri",
                table: "HesapHesapTipleri",
                columns: new[] { "HesapId", "HesapTipiId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HesapHesapTipleri_Hesaplar_HesapId",
                table: "HesapHesapTipleri",
                column: "HesapId",
                principalTable: "Hesaplar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HesapHesapTipleri_HesapTipleri_HesapTipiId",
                table: "HesapHesapTipleri",
                column: "HesapTipiId",
                principalTable: "HesapTipleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HesapHesapTipleri_Hesaplar_HesapId",
                table: "HesapHesapTipleri");

            migrationBuilder.DropForeignKey(
                name: "FK_HesapHesapTipleri_HesapTipleri_HesapTipiId",
                table: "HesapHesapTipleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HesapHesapTipleri",
                table: "HesapHesapTipleri");

            migrationBuilder.AlterColumn<int>(
                name: "HesapTipiId",
                table: "HesapHesapTipleri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HesapId",
                table: "HesapHesapTipleri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HesaplarId",
                table: "HesapHesapTipleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HesapTipleriId",
                table: "HesapHesapTipleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HesapHesapTipleri",
                table: "HesapHesapTipleri",
                columns: new[] { "HesaplarId", "HesapTipleriId" });

            migrationBuilder.CreateIndex(
                name: "IX_HesapHesapTipleri_HesapId",
                table: "HesapHesapTipleri",
                column: "HesapId");

            migrationBuilder.AddForeignKey(
                name: "FK_HesapHesapTipleri_Hesaplar_HesapId",
                table: "HesapHesapTipleri",
                column: "HesapId",
                principalTable: "Hesaplar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HesapHesapTipleri_HesapTipleri_HesapTipiId",
                table: "HesapHesapTipleri",
                column: "HesapTipiId",
                principalTable: "HesapTipleri",
                principalColumn: "Id");
        }
    }
}
