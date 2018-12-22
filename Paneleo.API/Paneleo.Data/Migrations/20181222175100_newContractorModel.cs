using Microsoft.EntityFrameworkCore.Migrations;

namespace Paneleo.Data.Migrations
{
    public partial class newContractorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Contractors",
                newName: "Www");

            migrationBuilder.RenameColumn(
                name: "Regon",
                table: "Contractors",
                newName: "StreetNumber");

            migrationBuilder.RenameColumn(
                name: "Forename",
                table: "Contractors",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "ContractorName",
                table: "Contractors",
                newName: "PostCode");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contractors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contractors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Contractors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Contractors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompany",
                table: "Contractors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Contractors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Contractors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCity",
                table: "Contractors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "IsCompany",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "PostCity",
                table: "Contractors");

            migrationBuilder.RenameColumn(
                name: "Www",
                table: "Contractors",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Contractors",
                newName: "Regon");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Contractors",
                newName: "Forename");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Contractors",
                newName: "ContractorName");
        }
    }
}
