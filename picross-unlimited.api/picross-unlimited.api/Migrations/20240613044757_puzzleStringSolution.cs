using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picross_Unlimited.Api.Migrations
{
    /// <inheritdoc />
    public partial class puzzleStringSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cells",
                table: "Puzzles",
                newName: "Solution");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Solution",
                table: "Puzzles",
                newName: "Cells");
        }
    }
}
