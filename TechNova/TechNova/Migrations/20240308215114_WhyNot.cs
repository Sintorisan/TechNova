using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechNova.Migrations
{
    /// <inheritdoc />
    public partial class WhyNot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartCartProduct");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "CartProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Carts_CartId",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Carts_CartId",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartProduct");

            migrationBuilder.CreateTable(
                name: "CartCartProduct",
                columns: table => new
                {
                    CartProductsId = table.Column<int>(type: "int", nullable: false),
                    CartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartCartProduct", x => new { x.CartProductsId, x.CartsId });
                    table.ForeignKey(
                        name: "FK_CartCartProduct_CartProduct_CartProductsId",
                        column: x => x.CartProductsId,
                        principalTable: "CartProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartCartProduct_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartCartProduct_CartsId",
                table: "CartCartProduct",
                column: "CartsId");
        }
    }
}
