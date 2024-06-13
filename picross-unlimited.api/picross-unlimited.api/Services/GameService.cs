using Microsoft.EntityFrameworkCore;
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

    public async Task<List<GameDetailsDto>> GetGameDetails(string username)
    {
        var player = Db.Users.FirstOrDefault(x => x.UserName == username);

        if (player == null)
        {
            return [];
        }

        var gameDetails = await Db.Games
            .Where(game => game.Username == player.UserName)
            .Include(game => game.Puzzle)
            .Select(game =>
                new GameDetailsDto()
                {
                    IsWin = game.IsWin,
                    NumberOfClicks = game.NumberOfClicks,
                    PuzzleId = game.PuzzleId,
                    PuzzleTitle = game.Puzzle!.Title,
                    DatePlayed = game.DatePlayed

                }
            ).ToListAsync();

        if(gameDetails is null)
        {
            return [];
        }

        return gameDetails;
    }

}

