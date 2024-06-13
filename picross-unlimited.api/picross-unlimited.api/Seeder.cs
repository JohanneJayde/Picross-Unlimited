namespace Picross_Unlimited.Api;
using Picross_Unlimited.Api.Models;

public class Seeder
{
    public static async Task Seed(AppDbContext db)
    {
        if (!db.Puzzles.Any())
        {

            List<Puzzle> puzzles = [

            new()
            {

                Title = "My First Puzzle",
                Description = "Here is my first Color",
                Difficulty = 1,
                Size = 2,
                ColorPalette = "{\"1\":\"one\",\"2\":\"two\",\"3\":\"three\"}",
                Solution = "[[1,0],[0,1]]",
                DateCreated = DateOnly.FromDateTime(DateTime.Now)
            },

            new()
            {

                Title = "My Second Puzzle",
                Description = "Here is my first second puzzle :)",
                Difficulty = 3,
                Size = 4,
                ColorPalette = "{\"1\":\"one\",\"2\":\"two\",\"3\":\"three\"}",
                Solution = "[[1,1,1,1],[1,0,0,1],[0,1,1,1],[1,0,1,1]]",
                DateCreated = DateOnly.FromDateTime(DateTime.Now)
            }

            ];

            db.Puzzles.AddRange(puzzles);
            await db.SaveChangesAsync();
        }
    }
}
