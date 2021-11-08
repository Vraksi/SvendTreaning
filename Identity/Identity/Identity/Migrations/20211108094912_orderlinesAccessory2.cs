using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class orderlinesAccessory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_ProductAccessories_ProductAccessoryId",
                table: "OrderLines");

            migrationBuilder.DropTable(
                name: "ProductAccessories");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductAccessoryId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ProductAccessoryId",
                table: "OrderLines");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderLines");

            migrationBuilder.AddColumn<int>(
                name: "ProductAccessoryId",
                table: "OrderLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductAccessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAccessories_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAccessories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductAccessoryId",
                table: "OrderLines",
                column: "ProductAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAccessories_AccessoryId",
                table: "ProductAccessories",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAccessories_ProductId",
                table: "ProductAccessories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_ProductAccessories_ProductAccessoryId",
                table: "OrderLines",
                column: "ProductAccessoryId",
                principalTable: "ProductAccessories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
