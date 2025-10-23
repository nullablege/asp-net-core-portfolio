using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTask1.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogAciklama",
                table: "Genels");

            migrationBuilder.DropColumn(
                name: "FooterHakkımda",
                table: "Genels");

            migrationBuilder.DropColumn(
                name: "HakkimdaAciklama",
                table: "Genels");

            migrationBuilder.DropColumn(
                name: "HizmetlerAciklama",
                table: "Genels");

            migrationBuilder.DropColumn(
                name: "IletisimAciklama",
                table: "Genels");

            migrationBuilder.DropColumn(
                name: "OzgecmisAciklama",
                table: "Genels");

            migrationBuilder.DropColumn(
                name: "ProjelerAciklama",
                table: "Genels");

            migrationBuilder.DropColumn(
                name: "YeteneklerAciklama",
                table: "Genels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogAciklama",
                table: "Genels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterHakkımda",
                table: "Genels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HakkimdaAciklama",
                table: "Genels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HizmetlerAciklama",
                table: "Genels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IletisimAciklama",
                table: "Genels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OzgecmisAciklama",
                table: "Genels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjelerAciklama",
                table: "Genels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YeteneklerAciklama",
                table: "Genels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
