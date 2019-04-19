using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoLp2.Migrations
{
    public partial class AtualizacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qtde",
                table: "Produto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RegistroVendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosVendidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Qtde = table.Column<int>(nullable: false),
                    preco = table.Column<double>(nullable: false),
                    ProdId = table.Column<int>(nullable: true),
                    RegistroVendasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosVendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosVendidos_Produto_ProdId",
                        column: x => x.ProdId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutosVendidos_RegistroVendas_RegistroVendasId",
                        column: x => x.RegistroVendasId,
                        principalTable: "RegistroVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosVendidos_ProdId",
                table: "ProdutosVendidos",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosVendidos_RegistroVendasId",
                table: "ProdutosVendidos",
                column: "RegistroVendasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosVendidos");

            migrationBuilder.DropTable(
                name: "RegistroVendas");

            migrationBuilder.DropColumn(
                name: "Qtde",
                table: "Produto");
        }
    }
}
