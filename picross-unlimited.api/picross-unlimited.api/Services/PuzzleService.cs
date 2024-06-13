
using Microsoft.AspNetCore.Http.HttpResults;
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
                Id = puzzle.PuzzleId,
                Title = puzzle.Title,
                Description = puzzle.Description,
                Difficulty = puzzle.Difficulty,
                Size = puzzle.Size,
                Solution = puzzle.Solution,
                DateCreated = puzzle.DateCreated,
                Creator = puzzle.Creator

            }).ToListAsync();
        }

        public async Task<PuzzleDto> GetPuzzle(int puzzleId)
        {
            var puzzle = await Db.Puzzles.FirstOrDefaultAsync(p => p.PuzzleId == puzzleId);

            PuzzleDto puzzleDto;

            if (puzzle is null)
            {
                throw new ResourceNotFoundException();
            }

            puzzleDto = new PuzzleDto
            {
                Id = puzzle.PuzzleId,
                Title = puzzle.Title,
                Description = puzzle.Description,
                Difficulty = puzzle.Difficulty,
                Size = puzzle.Size,
                Solution = puzzle.Solution,
                DateCreated = puzzle.DateCreated,
                Creator = puzzle.Creator

            };

            return puzzleDto;
        }

        public async Task<List<PuzzleDto>> GetUserPuzzles(string userName)
        {

            var puzzles = Db.Puzzles.Where(puzzle => puzzle.Creator == userName);

            if (puzzles is null)
            {
                throw new ResourceNotFoundException();
            }

            return await puzzles.Select(puzzle => new PuzzleDto
            {
                Id = puzzle.PuzzleId,
                Title = puzzle.Title,
                Description = puzzle.Description,
                Difficulty = puzzle.Difficulty,
                Size = puzzle.Size,
                Solution = puzzle.Solution,
                DateCreated = puzzle.DateCreated,
                Creator = puzzle.Creator

            }).ToListAsync();
        }

        public async Task<bool> SavePuzzle(UpdatePuzzleDto puzzleDto)
        {
            var puzzle = await Db.Puzzles.FirstOrDefaultAsync(puzzle => puzzle.PuzzleId == puzzleDto.Id);

            if (puzzle is not null)
            {

                puzzle.Solution = puzzleDto.Solution;
                puzzle.Difficulty = puzzleDto.Difficulty;
                puzzle.Title = puzzleDto.Title;
                puzzle.Size = puzzleDto.Size;
                puzzle.Description = puzzleDto.Description;

                await Db.SaveChangesAsync();
                return true;

            }
            return false;
        }

    }
}
