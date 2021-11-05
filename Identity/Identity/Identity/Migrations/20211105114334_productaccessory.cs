using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class productaccessory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessoriesAdded",
                table: "ProductAccessories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessoriesAdded",
                table: "ProductAccessories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
