using Microsoft.EntityFrameworkCore.Migrations;

namespace OchronaDanych_291118.Migrations
{
    public partial class IsLockedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LogTries",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LogTries",
                table: "Users");
        }
    }
}
