using Microsoft.EntityFrameworkCore.Migrations;

namespace GymEShop.Repository.Migrations
{
    public partial class addingQuantityToProductInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductInOrder",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductInOrder");
        }
    }
}
