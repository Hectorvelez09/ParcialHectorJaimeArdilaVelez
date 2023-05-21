using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StadiumTicketss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    EntranceGate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StadiumTicketss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntranceStadiumTickets",
                columns: table => new
                {
                    EntranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StadiumTicketsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceStadiumTickets", x => new { x.EntranceId, x.StadiumTicketsId });
                    table.ForeignKey(
                        name: "FK_EntranceStadiumTickets_Entrances_EntranceId",
                        column: x => x.EntranceId,
                        principalTable: "Entrances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntranceStadiumTickets_StadiumTicketss_StadiumTicketsId",
                        column: x => x.StadiumTicketsId,
                        principalTable: "StadiumTicketss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrances_Id",
                table: "Entrances",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntranceStadiumTickets_StadiumTicketsId",
                table: "EntranceStadiumTickets",
                column: "StadiumTicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_StadiumTicketss_Id",
                table: "StadiumTicketss",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntranceStadiumTickets");

            migrationBuilder.DropTable(
                name: "Entrances");

            migrationBuilder.DropTable(
                name: "StadiumTicketss");
        }
    }
}
