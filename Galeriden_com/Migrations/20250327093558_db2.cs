using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galeriden_com.Migrations
{
    /// <inheritdoc />
    public partial class db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlma_Arac_aracId",
                table: "SatinAlma");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlma_Musteri_musteriId",
                table: "SatinAlma");

            migrationBuilder.DropColumn(
                name: "AID",
                table: "SatinAlma");

            migrationBuilder.DropColumn(
                name: "MID",
                table: "SatinAlma");

            migrationBuilder.RenameColumn(
                name: "musteriId",
                table: "SatinAlma",
                newName: "MusteriID");

            migrationBuilder.RenameColumn(
                name: "aracId",
                table: "SatinAlma",
                newName: "AracID");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlma_musteriId",
                table: "SatinAlma",
                newName: "IX_SatinAlma_MusteriID");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlma_aracId",
                table: "SatinAlma",
                newName: "IX_SatinAlma_AracID");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlma_Arac_AracID",
                table: "SatinAlma",
                column: "AracID",
                principalTable: "Arac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlma_Musteri_MusteriID",
                table: "SatinAlma",
                column: "MusteriID",
                principalTable: "Musteri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlma_Arac_AracID",
                table: "SatinAlma");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlma_Musteri_MusteriID",
                table: "SatinAlma");

            migrationBuilder.RenameColumn(
                name: "MusteriID",
                table: "SatinAlma",
                newName: "musteriId");

            migrationBuilder.RenameColumn(
                name: "AracID",
                table: "SatinAlma",
                newName: "aracId");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlma_MusteriID",
                table: "SatinAlma",
                newName: "IX_SatinAlma_musteriId");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlma_AracID",
                table: "SatinAlma",
                newName: "IX_SatinAlma_aracId");

            migrationBuilder.AddColumn<int>(
                name: "AID",
                table: "SatinAlma",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MID",
                table: "SatinAlma",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlma_Arac_aracId",
                table: "SatinAlma",
                column: "aracId",
                principalTable: "Arac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlma_Musteri_musteriId",
                table: "SatinAlma",
                column: "musteriId",
                principalTable: "Musteri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
