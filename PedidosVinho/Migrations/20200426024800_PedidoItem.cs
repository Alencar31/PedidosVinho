using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidosVinho.Migrations
{
    public partial class PedidoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoItemId",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorUnitario = table.Column<decimal>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoItemId",
                table: "Produto",
                column: "PedidoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_PedidoItem_PedidoItemId",
                table: "Produto",
                column: "PedidoItemId",
                principalTable: "PedidoItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_PedidoItem_PedidoItemId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PedidoItemId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PedidoItemId",
                table: "Produto");
        }
    }
}
