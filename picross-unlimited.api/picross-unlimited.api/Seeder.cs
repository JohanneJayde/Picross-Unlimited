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
                Difficulty = 1,
                Size = 2,
                ColorPalette = "{\"1\":\"one\",\"2\":\"two\",\"3\":\"three\"}",
                Solution = "[[1,0],[0,1]]",
                DateCreated = DateOnly.FromDateTime(DateTime.Now)
            };


            await db.Puzzles.AddAsync(puzzle);
            await db.SaveChangesAsync();
        }
    }
}
