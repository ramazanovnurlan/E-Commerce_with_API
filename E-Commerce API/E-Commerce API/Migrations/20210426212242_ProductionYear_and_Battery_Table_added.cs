using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_API.Migrations
{
    public partial class ProductionYear_and_Battery_Table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Battery",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductionYear",
                table: "Products",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Battery",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionYear",
                table: "Products");
        }
    }
}
