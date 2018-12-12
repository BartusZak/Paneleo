using Microsoft.EntityFrameworkCore.Migrations;

namespace Paneleo.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contractors_ContractorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ContractorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ContractorId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractorId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContractorId",
                table: "Orders",
                column: "ContractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contractors_ContractorId",
                table: "Orders",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
