using Microsoft.AspNetCore.Mvc;
using Picross_Unlimited.Api.Dtos;
using Picross_Unlimited.Api.Services;

namespace Picross_Unlimited.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PuzzleController(PuzzleService PuzzleService) : Controller
{
   PuzzleService PuzzleService { get; set; } = PuzzleService;

    [HttpPost("AllPuzzles")]
    public async Task<List<PuzzleDto>> GetAllPuzzles()
    {
        var puzzles = await PuzzleService.GetAllPuzzles();
        return puzzles;
    }


}
