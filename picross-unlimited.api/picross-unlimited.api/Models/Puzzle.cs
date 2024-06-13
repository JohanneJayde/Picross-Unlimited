using System.ComponentModel.DataAnnotations;

namespace Picross_Unlimited.Api.Models;

    public class Puzzle
    {

    [Required]
    public int PuzzleId { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set;} = null!;
    public int Size { get; set; }

    public string ColorPalette { get; set; } = null!;

    public string Solution { get; set; } = null!;
    }

