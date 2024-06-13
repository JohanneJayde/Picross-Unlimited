using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Numerics;

namespace Picross_Unlimited.Api.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
            public DbSet<Puzzle> Puzzles { get; set; }

            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        // Make sure the identity db context on model creating is called
        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                //Make Cells be a json file
                builder.Entity<Puzzle>().OwnsOne(Puzzle => Puzzle.Cells, builder => { builder.ToJson(); });
            }
        }
    }


