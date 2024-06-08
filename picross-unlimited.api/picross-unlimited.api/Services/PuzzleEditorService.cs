
using Microsoft.EntityFrameworkCore;
using Picross_Unlimited.Api.Dtos;
using Picross_Unlimited.Api.Models;
namespace Picross_Unlimited.Api.Services
{
    public class PuzzleEditorService(AppDbContext Db)
    {
        public AppDbContext Db { get; set; } = Db;

        public async Task AddPuzzle(string Puzzle)
        {
          
        }

    }
}
