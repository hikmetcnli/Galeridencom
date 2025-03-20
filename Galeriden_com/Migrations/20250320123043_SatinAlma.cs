using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galeriden_com.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SatinAlma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MID = table.Column<int>(type: "int", nullable: false),
                    musteriId = table.Column<int>(type: "int", nullable: false),
                    AID = table.Column<int>(type: "int", nullable: false),
                    aracId = table.Column<int>(type: "int", nullable: false),
                    AlimFiyati = table.Column<double>(type: "float", nullable: false),
                    AlimFiyatiDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SatinAlma_Arac_aracId",
                        column: x => x.aracId,
                        principalTable: "Arac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatinAlma_Musteri_musteriId",
                        column: x => x.musteriId,
                        principalTable: "Musteri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlma_aracId",
                table: "SatinAlma",
                column: "aracId");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlma_musteriId",
                table: "SatinAlma",
                column: "musteriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatinAlma");
        }
    }
}
