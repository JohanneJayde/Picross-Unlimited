namespace Picross_Unlimited.Api.Dtos;

public class NewPuzzleDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Difficulty { get; set; }
    public int Size { get; set; }
    public DateTime DateCreated { get; set; }
    public string Color { get; set; } = null!;

    public int MaxClicks { get; set; }

    public string Solution { get; set; } = null!;

    public string Creator { get; set; } = null!;
}



