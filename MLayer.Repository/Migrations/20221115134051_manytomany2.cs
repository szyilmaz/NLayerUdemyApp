using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class manytomany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusteriMusteriTipi_MusteriTipi_MusteriTipleriId",
                table: "MusteriMusteriTipi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusteriTipi",
                table: "MusteriTipi");

            migrationBuilder.RenameTable(
                name: "MusteriTipi",
                newName: "MusteriTipleri");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusteriTipleri",
                table: "MusteriTipleri",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusteriMusteriTipi_MusteriTipleri_MusteriTipleriId",
                table: "MusteriMusteriTipi",
                column: "MusteriTipleriId",
                principalTable: "MusteriTipleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusteriMusteriTipi_MusteriTipleri_MusteriTipleriId",
                table: "MusteriMusteriTipi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusteriTipleri",
                table: "MusteriTipleri");

            migrationBuilder.RenameTable(
                name: "MusteriTipleri",
                newName: "MusteriTipi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusteriTipi",
                table: "MusteriTipi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusteriMusteriTipi_MusteriTipi_MusteriTipleriId",
                table: "MusteriMusteriTipi",
                column: "MusteriTipleriId",
                principalTable: "MusteriTipi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
