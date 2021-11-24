using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_API.Migrations
{
    public partial class SubmenuTitleID_Table_deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmenuTitleID",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubmenuTitleID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
