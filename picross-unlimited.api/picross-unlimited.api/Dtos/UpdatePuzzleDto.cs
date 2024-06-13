namespace Picross_Unlimited.Api.Dtos;

public class UpdatePuzzleDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Difficulty { get; set; }
    public int MaxClicks { get; set; }
    public string Color { get; set; } = null!;


    public string Solution { get; set; } = null!;

}

