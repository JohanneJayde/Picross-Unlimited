
using Microsoft.EntityFrameworkCore;
using Picross_Unlimited.Api.Dtos;
using Picross_Unlimited.Api.Models;
namespace Picross_Unlimited.Api.Services
{
    public class PuzzleService(AppDbContext Db)
    {
        public AppDbContext Db { get; set; } = Db;

        public async Task<List<PuzzleDto>> GetAllPuzzles()
        {
            return await Db.Puzzles.Select(puzzle => new PuzzleDto
            {
                Title = puzzle.Title,
                Description = puzzle.Description,
                Size = puzzle.Size,
                Solution = puzzle.Solution,
                ColorPalette = puzzle.ColorPalette,

            }).ToListAsync();
        }

    }
}
