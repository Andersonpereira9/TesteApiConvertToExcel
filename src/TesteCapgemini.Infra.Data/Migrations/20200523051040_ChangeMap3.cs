using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCapgemini.Infra.Data.Migrations
{
    public partial class ChangeMap3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorUnitario",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorUnitario",
                table: "Pedido",
                type: "decimal(2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
