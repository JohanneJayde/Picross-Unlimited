namespace Picross_Unlimited.Api;

using Azure.Identity;
using Microsoft.AspNetCore.Identity;
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
                Solution = "[[1,0],[0,1]]",
                Creator = "Admin@intellitect.com",
                Color = "green",
                MaxClicks = 5
            },

            new()
            {

                Title = "My Second Puzzle",
                Description = "Here is my first second puzzle :)",
                Difficulty = 3,
                Size = 4,
                Solution = "[[1,1,1,1],[1,0,0,1],[0,1,1,1],[1,0,1,1]]",
                DateCreated = DateOnly.FromDateTime(DateTime.Now),
                Creator = "Admin@intellitect.com",
                Color = "red",
                MaxClicks = 30

            }

            ];

            db.Puzzles.AddRange(puzzles);
            await db.SaveChangesAsync();
        }
    }
}
