using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concentrix.Migrations
{
    /// <inheritdoc />
    public partial class Concentrix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gerarPedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    dataPedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    valorTotalPedido = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gerarPedidos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gerarItens",
                columns: table => new
                {
                    idItem = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomePedido = table.Column<string>(type: "TEXT", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    valorUnitario = table.Column<double>(type: "REAL", nullable: false),
                    Pedidosid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gerarItens", x => x.idItem);
                    table.ForeignKey(
                        name: "FK_gerarItens_gerarPedidos_Pedidosid",
                        column: x => x.Pedidosid,
                        principalTable: "gerarPedidos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_gerarItens_Pedidosid",
                table: "gerarItens",
                column: "Pedidosid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gerarItens");

            migrationBuilder.DropTable(
                name: "gerarPedidos");
        }
    }
}
