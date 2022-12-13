using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class EmployeeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_AppUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Employee",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employee",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Employee",
                newName: "SurName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employee",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_AppUserId",
                table: "Employee",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
