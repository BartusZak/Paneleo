using Microsoft.EntityFrameworkCore.Migrations;

namespace Paneleo.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "ProductQuantity");

            migrationBuilder.RenameColumn(
                name: "PriceOfUnit",
                table: "Products",
                newName: "PricePerUnit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "PricePerUnit",
                table: "Products",
                newName: "PriceOfUnit");
        }
    }
}
