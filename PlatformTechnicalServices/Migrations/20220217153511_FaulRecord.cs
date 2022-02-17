using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatformTechnicalServices.Migrations
{
    public partial class FaulRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaultRecords",
                columns: table => new
                {
                    FaultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeknisyenId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtanmaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    FaultCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechnicianAssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultRecords", x => x.FaultId);
                    table.ForeignKey(
                        name: "FK_FaultRecords_AspNetUsers_TeknisyenId",
                        column: x => x.TeknisyenId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaultRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_TeknisyenId",
                table: "FaultRecords",
                column: "TeknisyenId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultRecords_UserId",
                table: "FaultRecords",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaultRecords");
        }
    }
}
