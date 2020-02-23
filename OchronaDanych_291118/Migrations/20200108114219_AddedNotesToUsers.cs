using Microsoft.EntityFrameworkCore.Migrations;

namespace OchronaDanych_291118.Migrations
{
    public partial class AddedNotesToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Notes_NoteId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NoteId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(nullable: true),
                    NoteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Email_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_NoteId",
                table: "Email",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NoteId",
                table: "Users",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Notes_NoteId",
                table: "Users",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
