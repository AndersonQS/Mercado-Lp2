using Microsoft.EntityFrameworkCore.Migrations;

namespace MercadoLp2.Migrations
{
    public partial class AtualizacaoDoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "RegistroVendas",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "RegistroVendas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
