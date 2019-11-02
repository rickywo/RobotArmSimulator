using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class update_command_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Command",
                table: "CommandLogs");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CommandLogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "CommandLogs");

            migrationBuilder.AddColumn<string>(
                name: "Command",
                table: "CommandLogs",
                nullable: true);
        }
    }
}
