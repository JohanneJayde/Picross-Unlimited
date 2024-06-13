using Microsoft.AspNetCore.Mvc;
using Picross_Unlimited.Api.Dtos;
using Picross_Unlimited.Api.Models;
using Picross_Unlimited.Api.Services;

namespace Picross_Unlimited.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PuzzleController(PuzzleService PuzzleService) : Controller
{
   PuzzleService PuzzleService { get; set; } = PuzzleService;

    [HttpGet("AllPuzzles")]
    public async Task<List<PuzzleDto>> GetAllPuzzles()
    {
        var puzzles = await PuzzleService.GetAllPuzzles();
        return puzzles;
    }

    [HttpGet("{id}")]
    public async Task<PuzzleDto> GetPuzzle( int id )
    {
        return await PuzzleService.GetPuzzle( id );
    }

    [HttpGet("Users/{username}")]

    public async Task<List<PuzzleDto>> GetUserPuzzles(string username)
    {
        var puzzles = await PuzzleService.GetUserPuzzles(username);
        return puzzles;
    }

    [HttpPost("SavePuzzle")]

    public async Task<bool> Save(UpdatePuzzleDto puzzle)
    {
        bool isSuccess = await PuzzleService.SavePuzzle(puzzle);

        return isSuccess;
    }

    [HttpPost("CreatePuzzle")]
    public async Task<int> Create(NewPuzzleDto puzzle) 
    { 
        int puzzleId = await PuzzleService.CreatePuzzle(puzzle);
        return puzzleId;
    }

}
