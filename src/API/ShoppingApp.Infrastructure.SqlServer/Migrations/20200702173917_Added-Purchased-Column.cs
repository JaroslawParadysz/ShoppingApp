using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApp.Infrastructure.SqlServer.Migrations
{
    public partial class AddedPurchasedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Purchased",
                table: "OrderProducts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purchased",
                table: "OrderProducts");
        }
    }
}
