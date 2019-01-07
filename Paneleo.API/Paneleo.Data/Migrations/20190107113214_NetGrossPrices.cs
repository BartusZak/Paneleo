using Microsoft.EntityFrameworkCore.Migrations;

namespace Paneleo.Data.Migrations
{
    public partial class NetGrossPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerUnit",
                table: "Products",
                newName: "NetPrice");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Orders",
                newName: "NetPrice");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "OrderProducts",
                newName: "NetPrice");

            migrationBuilder.AddColumn<double>(
                name: "GrossPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Vat",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GrossPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GrossPrice",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrossPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Vat",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GrossPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GrossPrice",
                table: "OrderProducts");

            migrationBuilder.RenameColumn(
                name: "NetPrice",
                table: "Products",
                newName: "PricePerUnit");

            migrationBuilder.RenameColumn(
                name: "NetPrice",
                table: "Orders",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "NetPrice",
                table: "OrderProducts",
                newName: "TotalCost");
        }
    }
}
