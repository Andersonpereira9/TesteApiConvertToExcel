using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCapgemini.Infra.Data.Migrations
{
    public partial class importacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ImportacaoModel_ImportacaoId",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportacaoModel",
                table: "ImportacaoModel");

            migrationBuilder.RenameTable(
                name: "ImportacaoModel",
                newName: "Importacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Importacao",
                table: "Importacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Importacao_ImportacaoId",
                table: "Pedido",
                column: "ImportacaoId",
                principalTable: "Importacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Importacao_ImportacaoId",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Importacao",
                table: "Importacao");

            migrationBuilder.RenameTable(
                name: "Importacao",
                newName: "ImportacaoModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportacaoModel",
                table: "ImportacaoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ImportacaoModel_ImportacaoId",
                table: "Pedido",
                column: "ImportacaoId",
                principalTable: "ImportacaoModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
