using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatformTechnicalServices.Migrations
{
    public partial class ArızaFiyatTablosuEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaultPrices",
                columns: table => new
                {
                    FaultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultPrices", x => x.FaultId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaultPrices");
        }
    }
}
