namespace Picross_Unlimited.Api;
using Picross_Unlimited.Api.Models;

public class Seeder
{
    public static async Task Seed(AppDbContext db)
    {
        if (!db.Puzzles.Any())
        {
            Puzzle puzzle = new()
            {
                Title = "My First Puzzle",
                Description = "Here is my first Color",
                Size = 9,
                ColorPalette = "{\r\n  \"colorPalette\": [\r\n    {\r\n      \"1\": \"red\"\r\n    }\r\n  ]\r\n}",
                Solution = "{\r\n  \"solution\": \"[1,0,0,1]\"\r\n}"
            };


            await db.Puzzles.AddAsync(puzzle);
            await db.SaveChangesAsync();
        }
    }
}
