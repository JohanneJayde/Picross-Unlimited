using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;
using System;
using Picross_Unlimited.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Picross_Unlimited.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if(!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }

    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User
        if(await userManager.FindByEmailAsync("Admin@Admin.com") == null)
        {
            AppUser user = new AppUser
            {
                ProfileColor = "Secondary",
                ProfileIcon = "\\eb3b",
                UserName = "Admin",
                Email = "Admin@Admin.com"
            };
            IdentityResult result = userManager.CreateAsync(user, "Password123").Result;

            if(result.Succeeded)
            {
                await userManager.CreateAsync(user, Roles.Admin);
            }
        }

    }
    //i don't think this is needed. Need second opinion. Creates a default user
    private static async Task SeedUserAccountAsync(UserManager<AppUser> appUser, RoleManager<IdentityRole> roleManager, AppDbContext context )
    {
        var userEmails = new[]
        {
            new {UserName = "Admin", Email = "Admin@Admin.com", Role = "Admin", ProfileColor = "Secondary", ProfileIcon = "\\eb3b"}
        };
        foreach(var allUsers in userEmails)
        {
            if(!context.Users.Any( u => u.UserName == allUsers.UserName))
            {
                AppUser user = new AppUser
                {
                    ProfileIcon = "\\eb3b",
                    ProfileColor = "Primary",
                    UserName = "new_user",
                    Email = "default@default.com"

                };
                var result = await appUser.CreateAsync(user, allUsers.Email);
                if(result.Succeeded)
                {
                    await appUser.AddToRoleAsync(user, allUsers.Role);
                }
            }

        }
       

    }
}