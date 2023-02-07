using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbTripalTest.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Palety",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dlugosc = table.Column<int>(type: "int", nullable: false),
                    Szerokosc = table.Column<int>(type: "int", nullable: false),
                    Wysokosc = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palety", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaProduktu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WagaProduktu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    A = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    B = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IloscWejsciowa = table.Column<int>(type: "int", nullable: true),
                    DataUworzenia = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataOstatniejAktualizacji = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uklady",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUkladu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IloscWarstw = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    PaletaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uklady", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uklady_Palety_PaletaId",
                        column: x => x.PaletaId,
                        principalTable: "Palety",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Uklady_Produkty_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warstwy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUworzenia = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DataOstatniejAktualizacji = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ProduktId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warstwy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warstwy_Produkty_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pakiety",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerPakietu = table.Column<int>(type: "int", nullable: true),
                    X = table.Column<int>(type: "int", nullable: true),
                    Z = table.Column<int>(type: "int", nullable: true),
                    Y = table.Column<int>(type: "int", nullable: true),
                    IloscProduktow = table.Column<int>(type: "int", nullable: true),
                    Obrot = table.Column<int>(type: "int", nullable: true),
                    OrientacjaPobrania = table.Column<int>(type: "int", nullable: true),
                    WymiarX = table.Column<int>(type: "int", nullable: true),
                    WymiarY = table.Column<int>(type: "int", nullable: true),
                    Xoff = table.Column<int>(type: "int", nullable: true),
                    Yoff = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    WarstwaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pakiety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pakiety_Warstwy_WarstwaId",
                        column: x => x.WarstwaId,
                        principalTable: "Warstwy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poziomy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerPoziomu = table.Column<int>(type: "int", nullable: false),
                    Przekladka = table.Column<bool>(type: "bit", nullable: false),
                    WysokoscWarstwy = table.Column<int>(type: "int", nullable: false),
                    PaletaJakoPrzekladka = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    WarstwaId = table.Column<int>(type: "int", nullable: false),
                    UkladId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poziomy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poziomy_Uklady_UkladId",
                        column: x => x.UkladId,
                        principalTable: "Uklady",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poziomy_Warstwy_WarstwaId",
                        column: x => x.WarstwaId,
                        principalTable: "Warstwy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pakiety_WarstwaId",
                table: "Pakiety",
                column: "WarstwaId");

            migrationBuilder.CreateIndex(
                name: "IX_Poziomy_UkladId",
                table: "Poziomy",
                column: "UkladId");

            migrationBuilder.CreateIndex(
                name: "IX_Poziomy_WarstwaId",
                table: "Poziomy",
                column: "WarstwaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uklady_PaletaId",
                table: "Uklady",
                column: "PaletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uklady_ProduktId",
                table: "Uklady",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Warstwy_ProduktId",
                table: "Warstwy",
                column: "ProduktId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pakiety");

            migrationBuilder.DropTable(
                name: "Poziomy");

            migrationBuilder.DropTable(
                name: "Uklady");

            migrationBuilder.DropTable(
                name: "Warstwy");

            migrationBuilder.DropTable(
                name: "Palety");

            migrationBuilder.DropTable(
                name: "Produkty");
        }
    }
}
