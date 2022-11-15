using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class bankaSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bankalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subeler_Bankalar_BankaId",
                        column: x => x.BankaId,
                        principalTable: "Bankalar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hesaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    SubeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hesaplar_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hesaplar_Subeler_SubeId",
                        column: x => x.SubeId,
                        principalTable: "Subeler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hareketler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipi = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HesapId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hareketler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hareketler_Hesaplar_HesapId",
                        column: x => x.HesapId,
                        principalTable: "Hesaplar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_HesapId",
                table: "Hareketler",
                column: "HesapId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_MusteriId",
                table: "Hesaplar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_SubeId",
                table: "Hesaplar",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subeler_BankaId",
                table: "Subeler",
                column: "BankaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hareketler");

            migrationBuilder.DropTable(
                name: "Hesaplar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Subeler");

            migrationBuilder.DropTable(
                name: "Bankalar");
        }
    }
}
