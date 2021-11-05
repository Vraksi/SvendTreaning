using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class orderlines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessoriesAdded",
                table: "OrderLines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessoriesAdded",
                table: "OrderLines");
        }
    }
}
