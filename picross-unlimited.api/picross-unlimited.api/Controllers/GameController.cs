using Microsoft.AspNetCore.Mvc;
using Picross_Unlimited.Api.Dtos;
using Picross_Unlimited.Api.Services;

namespace Picross_Unlimited.Api.Controllers;


[Route("[controller]")]
[ApiController]
public class GameController(GameService GameService) : ControllerBase
{
    public GameService GameService { get; set; } = GameService;


    [HttpPost("Post")]
    public async Task<bool> PostGame(GameDto game)
    {
        bool isSuccessful = await GameService.SaveGame(game);

        return isSuccessful;
    }

    [HttpGet("Stats/${username}")]
    public async Task<List<GameDetailsDto>> GetAllGameStats(string username)
    {
        var gameDetails = await GameService.GetGameDetails(username);

        return gameDetails;
    }
}

