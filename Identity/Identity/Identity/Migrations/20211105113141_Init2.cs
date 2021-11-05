using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_ProductAccessory_ProductAccessoryId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAccessory_Accessories_AccessoryId",
                table: "ProductAccessory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAccessory_Products_ProductId",
                table: "ProductAccessory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAccessory",
                table: "ProductAccessory");

            migrationBuilder.RenameTable(
                name: "ProductAccessory",
                newName: "ProductAccessories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAccessory_ProductId",
                table: "ProductAccessories",
                newName: "IX_ProductAccessories_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAccessory_AccessoryId",
                table: "ProductAccessories",
                newName: "IX_ProductAccessories_AccessoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAccessories",
                table: "ProductAccessories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_ProductAccessories_ProductAccessoryId",
                table: "OrderLines",
                column: "ProductAccessoryId",
                principalTable: "ProductAccessories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAccessories_Accessories_AccessoryId",
                table: "ProductAccessories",
                column: "AccessoryId",
                principalTable: "Accessories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAccessories_Products_ProductId",
                table: "ProductAccessories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_ProductAccessories_ProductAccessoryId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAccessories_Accessories_AccessoryId",
                table: "ProductAccessories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAccessories_Products_ProductId",
                table: "ProductAccessories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAccessories",
                table: "ProductAccessories");

            migrationBuilder.RenameTable(
                name: "ProductAccessories",
                newName: "ProductAccessory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAccessories_ProductId",
                table: "ProductAccessory",
                newName: "IX_ProductAccessory_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAccessories_AccessoryId",
                table: "ProductAccessory",
                newName: "IX_ProductAccessory_AccessoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAccessory",
                table: "ProductAccessory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_ProductAccessory_ProductAccessoryId",
                table: "OrderLines",
                column: "ProductAccessoryId",
                principalTable: "ProductAccessory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAccessory_Accessories_AccessoryId",
                table: "ProductAccessory",
                column: "AccessoryId",
                principalTable: "Accessories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAccessory_Products_ProductId",
                table: "ProductAccessory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
