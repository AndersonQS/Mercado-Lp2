using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoLp2.Migrations
{
    public partial class AlteracaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "preco",
                table: "ProdutosVendidos",
                newName: "Preco");

            migrationBuilder.AddColumn<int>(
                name: "VendedorId",
                table: "RegistroVendas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ProdutoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedor_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVendas_VendedorId",
                table: "RegistroVendas",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_ProdutoId",
                table: "Vendedor",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroVendas_Vendedor_VendedorId",
                table: "RegistroVendas",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroVendas_Vendedor_VendedorId",
                table: "RegistroVendas");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropIndex(
                name: "IX_RegistroVendas_VendedorId",
                table: "RegistroVendas");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "RegistroVendas");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "ProdutosVendidos",
                newName: "preco");
        }
    }
}
