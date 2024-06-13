namespace Picross_Unlimited.Api.Dtos;

public class PuzzleDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Difficulty { get; set; }
    public int Size { get; set; }
    public DateOnly DateCreated { get; set; }

    public string ColorPalette { get; set; } = null!;

    public string Solution { get; set; } = null!;

    public string Creator { get; set; } = null!;
}

