using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class manytomany1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusteriTipi",
                table: "Musteriler");

            migrationBuilder.CreateTable(
                name: "MusteriTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriTipi", x => x.Id);
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
                        name: "FK_MusteriMusteriTipi_MusteriTipi_MusteriTipleriId",
                        column: x => x.MusteriTipleriId,
                        principalTable: "MusteriTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusteriMusteriTipi_MusterilerId",
                table: "MusteriMusteriTipi",
                column: "MusterilerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusteriMusteriTipi");

            migrationBuilder.DropTable(
                name: "MusteriTipi");

            migrationBuilder.AddColumn<int>(
                name: "MusteriTipi",
                table: "Musteriler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
