using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class constrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Employees",
                type: "int",
                maxLength: 12,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SSN",
                table: "Employees",
                type: "int",
                maxLength: 14,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "email_unique",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "phone_unique",
                table: "Employees",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ssn_unique",
                table: "Employees",
                column: "SSN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "email_unique",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "phone_unique",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "ssn_unique",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "Employees");
        }
    }
}
