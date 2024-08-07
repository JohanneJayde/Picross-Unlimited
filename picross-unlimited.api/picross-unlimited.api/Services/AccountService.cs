using Microsoft.AspNetCore.Identity;
using Picross_Unlimited.Api.Helpers;
using Picross_Unlimited.Api.Models;

namespace Picross_Unlimited.Api.Services;

public class AccountService(UserManager<AppUser> UserManager)
{
    public async Task<ItemResult> Register(string email, string username, string password)
    {
        var user = await UserManager.FindByEmailAsync(email);

        if (user is not null)
        {
            return new ItemResult(wasSuccessful: false, message: "Registration failed due to provided info");
        }

        AppUser newUser = new()
        {
            Email = email,
            UserName = username,
            ProfileColor = "blue",
            ProfileIcon = "mdi-account"
        };

        var result = await UserManager.CreateAsync(newUser, password);

        if (result.Succeeded)
        {
            return new ItemResult(true, "Account successfully registered");
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return new ItemResult(false, string.Join(" ",errors));
        }

    }

}

