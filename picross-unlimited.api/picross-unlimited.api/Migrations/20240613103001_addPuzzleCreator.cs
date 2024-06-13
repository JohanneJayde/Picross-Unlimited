using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picross_Unlimited.Api.Migrations
{
    /// <inheritdoc />
    public partial class addPuzzleCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Puzzles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Puzzles");
        }
    }
}
