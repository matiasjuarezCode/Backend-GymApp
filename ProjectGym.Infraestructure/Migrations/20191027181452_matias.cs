using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectGym.Infraestructure.Migrations
{
    public partial class matias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "User_Username",
                table: "Employees",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "User_Password",
                table: "Employees",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Employees",
                newName: "User_Username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employees",
                newName: "User_Password");

            migrationBuilder.AlterColumn<string>(
                name: "User_Username",
                table: "Employees",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "User_Password",
                table: "Employees",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<long>(
                name: "User_Id",
                table: "Employees",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
