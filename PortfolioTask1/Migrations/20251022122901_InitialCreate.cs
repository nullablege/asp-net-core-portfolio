using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTask1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genels",
                columns: table => new
                {
                    GenelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HakkimdaAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OzgecmisAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HizmetlerAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YeteneklerAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjelerAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdulSayisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BitenProjeSayisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MutluMusteriSayisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KahveSayisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FctoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FctoSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IletisimAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IletisimAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İletisimNumara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İletisimMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İletisimWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterHakkımda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İnstagram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genels", x => x.GenelId);
                });

            migrationBuilder.CreateTable(
                name: "Hakkimdas",
                columns: table => new
                {
                    HakkimdaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogumTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeSayısı = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkimdas", x => x.HakkimdaId);
                });

            migrationBuilder.CreateTable(
                name: "ıletisimForms",
                columns: table => new
                {
                    IletisimFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goruldu = table.Column<bool>(type: "bit", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ıletisimForms", x => x.IletisimFormId);
                });

            migrationBuilder.CreateTable(
                name: "Ozgecmiss",
                columns: table => new
                {
                    OzgecmisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seviye = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kurum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ozgecmiss", x => x.OzgecmisId);
                });

            migrationBuilder.CreateTable(
                name: "Projelerims",
                columns: table => new
                {
                    ProjelerimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeSinifi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeBoyutu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeResim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projelerims", x => x.ProjelerimId);
                });

            migrationBuilder.CreateTable(
                name: "Yeteneklerims",
                columns: table => new
                {
                    YeteneklerimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YetenekAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetenekSeviyesi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yeteneklerims", x => x.YeteneklerimId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genels");

            migrationBuilder.DropTable(
                name: "Hakkimdas");

            migrationBuilder.DropTable(
                name: "ıletisimForms");

            migrationBuilder.DropTable(
                name: "Ozgecmiss");

            migrationBuilder.DropTable(
                name: "Projelerims");

            migrationBuilder.DropTable(
                name: "Yeteneklerims");
        }
    }
}
