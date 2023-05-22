using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntranceGates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceGates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tikets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tikets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntranceGateTikets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntranceGateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceGateTikets", x => new { x.TicketId, x.EntranceGateId });
                    table.ForeignKey(
                        name: "FK_EntranceGateTikets_EntranceGates_EntranceGateId",
                        column: x => x.EntranceGateId,
                        principalTable: "EntranceGates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntranceGateTikets_Tikets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tikets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntranceGates_Id",
                table: "EntranceGates",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntranceGateTikets_EntranceGateId",
                table: "EntranceGateTikets",
                column: "EntranceGateId");

            migrationBuilder.CreateIndex(
                name: "IX_Tikets_Id",
                table: "Tikets",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntranceGateTikets");

            migrationBuilder.DropTable(
                name: "EntranceGates");

            migrationBuilder.DropTable(
                name: "Tikets");
        }
    }
}
