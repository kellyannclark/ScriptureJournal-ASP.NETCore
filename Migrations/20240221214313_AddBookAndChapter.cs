using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyScriptureJournal.Migrations
{
    /// <inheritdoc />
    public partial class AddBookAndChapter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookOf",
                table: "Scriptures",
                newName: "BookAndChapter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookAndChapter",
                table: "Scriptures",
                newName: "BookOf");
        }
    }
}
