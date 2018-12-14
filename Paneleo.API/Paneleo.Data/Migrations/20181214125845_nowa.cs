using Microsoft.EntityFrameworkCore.Migrations;

namespace Paneleo.Data.Migrations
{
    public partial class nowa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Contractors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedById",
                table: "Products",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ModifiedById",
                table: "Orders",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ModifiedById",
                table: "OrderProducts",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_ModifiedById",
                table: "Contractors",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Contractors_Users_ModifiedById",
                table: "Contractors",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Users_ModifiedById",
                table: "OrderProducts",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ModifiedById",
                table: "Orders",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_ModifiedById",
                table: "Products",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractors_Users_ModifiedById",
                table: "Contractors");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Users_ModifiedById",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ModifiedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_ModifiedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModifiedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ModifiedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_ModifiedById",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_Contractors_ModifiedById",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Contractors");
        }
    }
}
