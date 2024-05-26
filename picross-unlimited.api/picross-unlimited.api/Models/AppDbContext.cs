using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Numerics;

namespace Picross_Unlimited.Api.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {



            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        // Make sure the identity db ocntext on model creating is called
        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }
        }
    }


