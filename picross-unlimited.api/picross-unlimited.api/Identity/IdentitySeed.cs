using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;
using System;
using Picross_Unlimited.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Picross_Unlimited.Api.Identity;

public static class IdentitySeed
{
    public static async Task SeedAsync(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        AppDbContext db
    )
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User

        if (await userManager.FindByEmailAsync("Admin@PicrossUnlimited.com") == null)
        {
            AppUser user = new AppUser
            {
                ProfileColor = "Secondary",
                ProfileIcon = "\\eb3b",
                UserName = "Admin",
                Email = "Admin@PicrossUnlimited.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }

        if (await userManager.FindByEmailAsync("Johanne@PicrossUnlimited.com") == null)
        {
            AppUser user = new AppUser
            {
                ProfileColor = "Secondary",
                ProfileIcon = "\\eb3b",
                UserName = "JohanneJayde",
                Email = "Johanne@PicrossUnlimited.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }

        if (await userManager.FindByEmailAsync("Woobly@PicrossUnlimited.com") == null)
        {
            AppUser user = new AppUser
            {
                ProfileColor = "Secondary",
                ProfileIcon = "\\eb3b",
                UserName = "Woobly",
                Email = "Woobly@PicrossUnlimited.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }

        if (await userManager.FindByEmailAsync("Spencer@PicrossUnlimited.com") == null)
        {
            AppUser user = new AppUser
            {
                ProfileColor = "Secondary",
                ProfileIcon = "\\eb3b",
                UserName = "Spencer",
                Email = "Spencer@PicrossUnlimited.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }
    }
}
