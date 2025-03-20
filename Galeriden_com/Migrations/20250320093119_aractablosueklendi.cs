using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galeriden_com.Migrations
{
    /// <inheritdoc />
    public partial class aractablosueklendi : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arac");
        }
    }
}
