using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class CreateAppUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_AppUserId1",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AppUserId1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_AppUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AppUserId1",
                table: "Employee",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_AppUserId1",
                table: "Employee",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
