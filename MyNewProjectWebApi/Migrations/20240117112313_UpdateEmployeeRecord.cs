using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewProjectApi.Migrations
{
    public partial class UpdateEmployeeRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "EmployeeDetails");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "EmployeeDetails",
                newName: "EmailAddress");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "EmployeeDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "EmployeeDetails");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "EmployeeDetails",
                newName: "Email");

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "EmployeeDetails",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
