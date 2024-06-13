namespace Picross_Unlimited.Api.Dtos;

public class PuzzleDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Size { get; set; }

    public string ColorPalette { get; set; } = null!;

    public string Solution { get; set; } = null!;
}

