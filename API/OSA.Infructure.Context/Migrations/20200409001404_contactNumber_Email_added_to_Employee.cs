using Microsoft.EntityFrameworkCore.Migrations;

namespace OSA.Infructure.Context.Migrations
{
    public partial class contactNumber_Email_added_to_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactNumber",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");
        }
    }
}
