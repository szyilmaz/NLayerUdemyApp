using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class lokasyon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LokasyonId",
                table: "Subeler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lokasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokasyonlar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subeler_LokasyonId",
                table: "Subeler",
                column: "LokasyonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_Lokasyonlar_LokasyonId",
                table: "Subeler",
                column: "LokasyonId",
                principalTable: "Lokasyonlar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_Lokasyonlar_LokasyonId",
                table: "Subeler");

            migrationBuilder.DropTable(
                name: "Lokasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Subeler_LokasyonId",
                table: "Subeler");

            migrationBuilder.DropColumn(
                name: "LokasyonId",
                table: "Subeler");
        }
    }
}
