using Microsoft.AspNetCore.Identity;

namespace Picross_Unlimited.Api.Models
{
        public class AppUser : IdentityUser
        {
            //TODO
            // ADD PROFILE ICON
            public string ProfileIcon { get; set; } = null!;
            // ADD COLOR
            public string ProfileColor { get; set; } = null!;
        }
    }
