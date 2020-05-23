using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCapgemini.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportacaoModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataImportacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportacaoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorUnitario = table.Column<decimal>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    ImportacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_ImportacaoModel_ImportacaoId",
                        column: x => x.ImportacaoId,
                        principalTable: "ImportacaoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ImportacaoId",
                table: "Pedido",
                column: "ImportacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "ImportacaoModel");
        }
    }
}
