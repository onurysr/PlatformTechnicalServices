using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatformTechnicalServices.Migrations
{
    public partial class subjectEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "FaultRecords",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "FaultRecords");
        }
    }
}
