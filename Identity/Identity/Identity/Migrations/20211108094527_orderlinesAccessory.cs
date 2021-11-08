using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class orderlinesAccessory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderLineId",
                table: "Accessories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_OrderLineId",
                table: "Accessories",
                column: "OrderLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_OrderLines_OrderLineId",
                table: "Accessories",
                column: "OrderLineId",
                principalTable: "OrderLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_OrderLines_OrderLineId",
                table: "Accessories");

            migrationBuilder.DropIndex(
                name: "IX_Accessories_OrderLineId",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "OrderLineId",
                table: "Accessories");
        }
    }
}
