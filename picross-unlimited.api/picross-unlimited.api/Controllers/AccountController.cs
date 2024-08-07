using Microsoft.AspNetCore.Mvc;
using Picross_Unlimited.Api.Services;

namespace Picross_Unlimited.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController(AccountService AccountService) : ControllerBase
{
    AccountService AccountService { get; set; } = AccountService;

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        var result = await AccountService.Register(userDto.Email, userDto.Username, userDto.Password);

        if (result.WasSuccessful)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
}

public class UserDto
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

