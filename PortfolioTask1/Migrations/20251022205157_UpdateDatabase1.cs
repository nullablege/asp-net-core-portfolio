using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTask1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aciklama",
                table: "Hakkimdas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aciklama",
                table: "Hakkimdas");
        }
    }
}
