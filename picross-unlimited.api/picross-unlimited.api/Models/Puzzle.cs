using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picross_Unlimited.Api.Models;

    public class Puzzle
    {

    [Required]
    public int PuzzleId { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set;} = null!;

    [Range(0, 10)]
    public int Difficulty { get; set; }
    public int Size { get; set; }
    public DateOnly DateCreated { get; set; }

    public string ColorPalette { get; set; } = null!;

    public string Solution { get; set; } = null!;
    }

