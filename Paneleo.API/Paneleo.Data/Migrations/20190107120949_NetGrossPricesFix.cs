using Microsoft.EntityFrameworkCore.Migrations;

namespace Paneleo.Data.Migrations
{
    public partial class NetGrossPricesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NetPrice",
                table: "OrderProducts",
                newName: "TotalNetPrice");

            migrationBuilder.RenameColumn(
                name: "GrossPrice",
                table: "OrderProducts",
                newName: "TotalGrossPrice");

            migrationBuilder.AlterColumn<double>(
                name: "Vat",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalNetPrice",
                table: "OrderProducts",
                newName: "NetPrice");

            migrationBuilder.RenameColumn(
                name: "TotalGrossPrice",
                table: "OrderProducts",
                newName: "GrossPrice");

            migrationBuilder.AlterColumn<string>(
                name: "Vat",
                table: "Products",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
