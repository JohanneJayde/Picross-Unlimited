using Picross_Unlimited.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Picross_Unlimited.Api.Dtos;

public class GameDto
{
    public string Username { get; set; } = null!;
    public bool IsWin { get; set; }
    public int NumberOfClicks { get; set; }
    public int PuzzleId { get; set; }
}
    

