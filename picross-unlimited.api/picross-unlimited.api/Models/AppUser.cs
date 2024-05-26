using Microsoft.AspNetCore.Identity;

namespace Picross_Unlimited.Api.Models
{
        public class AppUser : IdentityUser
        {
            public int GameCount { get; set; }

            public double AverageAttempts { get; set; }

            public int AverageSecondsPerGame { get; set; }
        }
    }
