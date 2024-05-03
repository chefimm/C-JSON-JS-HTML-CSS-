using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Tc = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    Tel = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OduncKitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    UyeId = table.Column<int>(type: "int", nullable: false),
                    AlisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GetirdigiTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UyeModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OduncKitaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OduncKitaplar_Uyeler_UyeModelId",
                        column: x => x.UyeModelId,
                        principalTable: "Uyeler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Isbn = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yazarlar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KategoriModelKitapModel",
                columns: table => new
                {
                    KategorilerId = table.Column<int>(type: "int", nullable: false),
                    KitaplarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriModelKitapModel", x => new { x.KategorilerId, x.KitaplarId });
                    table.ForeignKey(
                        name: "FK_KategoriModelKitapModel_Kategoriler_KategorilerId",
                        column: x => x.KategorilerId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategoriModelKitapModel_Kitaplar_KitaplarId",
                        column: x => x.KitaplarId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KategoriModelKitapModel_KitaplarId",
                table: "KategoriModelKitapModel",
                column: "KitaplarId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YazarId",
                table: "Kitaplar",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_OduncKitaplar_UyeModelId",
                table: "OduncKitaplar",
                column: "UyeModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategoriModelKitapModel");

            migrationBuilder.DropTable(
                name: "OduncKitaplar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Uyeler");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
