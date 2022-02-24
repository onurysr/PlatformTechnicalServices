using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatformTechnicalServices.Migrations
{
    public partial class faulttablosunaoperatoreklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OperatorId",
                table: "FaultRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_OperatorId",
                table: "FaultRecords",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultRecords_AspNetUsers_OperatorId",
                table: "FaultRecords",
                column: "OperatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaultRecords_AspNetUsers_OperatorId",
                table: "FaultRecords");

            migrationBuilder.DropIndex(
                name: "IX_FaultRecords_OperatorId",
                table: "FaultRecords");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "FaultRecords");
        }
    }
}
