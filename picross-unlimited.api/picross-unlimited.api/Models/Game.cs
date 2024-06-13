using System.ComponentModel.DataAnnotations;

namespace Picross_Unlimited.Api.Models;

public class Game
{
    public int GameId { get; set; }
    public string Username { get; set; } = null!;
    public bool IsWin { get; set; }
    public DateTime DatePlayed { get; set; } = DateTime.Now;
    public int NumberOfClicks { get; set; }

    [Required]
    public int PuzzleId { get; set; }
    public Puzzle? Puzzle { get; set; }

}

