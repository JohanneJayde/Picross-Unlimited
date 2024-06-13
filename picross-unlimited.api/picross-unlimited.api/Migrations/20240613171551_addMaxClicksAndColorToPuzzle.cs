using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picross_Unlimited.Api.Migrations
{
    /// <inheritdoc />
    public partial class addMaxClicksAndColorToPuzzle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Puzzles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxClicks",
                table: "Puzzles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "MaxClicks",
                table: "Puzzles");
        }
    }
}
