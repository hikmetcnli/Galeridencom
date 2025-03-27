using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galeriden_com.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Plaka = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

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
                name: "Products");

            migrationBuilder.DropTable(
                name: "SatinAlma");

            migrationBuilder.DropTable(
                name: "Arac");

            migrationBuilder.DropTable(
                name: "Musteri");
        }
    }
}
