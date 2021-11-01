using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Cobertura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cobertura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Recheio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Recheio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Churros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Tamanho = table.Column<int>(type: "int", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    CoberturaId = table.Column<int>(type: "int", nullable: false),
                    RecheioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Churros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Churros_Tbl_Cobertura_CoberturaId",
                        column: x => x.CoberturaId,
                        principalTable: "Tbl_Cobertura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Churros_Tbl_Recheio_RecheioId",
                        column: x => x.RecheioId,
                        principalTable: "Tbl_Recheio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Churros_Pedido",
                columns: table => new
                {
                    ChurrosId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Churros_Pedido", x => new { x.ChurrosId, x.PedidoId });
                    table.ForeignKey(
                        name: "FK_Tbl_Churros_Pedido_Tbl_Churros_ChurrosId",
                        column: x => x.ChurrosId,
                        principalTable: "Tbl_Churros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Churros_Pedido_Tbl_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Tbl_Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Churros_CoberturaId",
                table: "Tbl_Churros",
                column: "CoberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Churros_RecheioId",
                table: "Tbl_Churros",
                column: "RecheioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Churros_Pedido_PedidoId",
                table: "Tbl_Churros_Pedido",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Churros_Pedido");

            migrationBuilder.DropTable(
                name: "Tbl_Churros");

            migrationBuilder.DropTable(
                name: "Tbl_Pedido");

            migrationBuilder.DropTable(
                name: "Tbl_Cobertura");

            migrationBuilder.DropTable(
                name: "Tbl_Recheio");
        }
    }
}
