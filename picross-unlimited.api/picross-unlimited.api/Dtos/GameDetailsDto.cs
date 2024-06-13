namespace Picross_Unlimited.Api.Dtos;

public class GameDetailsDto
{
    public bool IsWin { get; set; }
    public int NumberOfClicks { get; set; }
    public int PuzzleId { get; set; }
    public string PuzzleTitle { get; set; } = null!;
    public DateTime DatePlayed { get; set; } = DateTime.Now;

}

