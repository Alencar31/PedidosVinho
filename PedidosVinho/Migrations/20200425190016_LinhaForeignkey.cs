using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidosVinho.Migrations
{
    public partial class LinhaForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Linha_LinhaId",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "LinhaId",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Linha_LinhaId",
                table: "Produto",
                column: "LinhaId",
                principalTable: "Linha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Linha_LinhaId",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "LinhaId",
                table: "Produto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Linha_LinhaId",
                table: "Produto",
                column: "LinhaId",
                principalTable: "Linha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
