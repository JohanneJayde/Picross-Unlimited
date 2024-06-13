using Picross_Unlimited.Api.Dtos;
using Picross_Unlimited.Api.Models;

namespace Picross_Unlimited.Api.Services;

public class GameService(AppDbContext Db)
{
    AppDbContext Db { get; set; } = Db;

    public async Task<bool> SaveGame(GameDto game)
    {
        var Game = new Game()
        {
            Username = game.Username,
            IsWin = game.IsWin,
            NumberOfClicks = game.NumberOfClicks,
            PuzzleId = game.PuzzleId,
            Puzzle = Db.Puzzles.FirstOrDefault(puzzle => puzzle.PuzzleId == game.PuzzleId)

        };

        Db.Games.Add(Game);

        await Db.SaveChangesAsync();

        return true;
    }

}

