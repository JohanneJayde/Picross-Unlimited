using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picross_Unlimited.Api.Migrations
{
    /// <inheritdoc />
    public partial class puzzleColorPalatte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorPalette",
                table: "Puzzles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorPalette",
                table: "Puzzles");
        }
    }
}
