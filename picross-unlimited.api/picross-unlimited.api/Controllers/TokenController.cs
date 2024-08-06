﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Picross_Unlimited.Api.Identity;
using Picross_Unlimited.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Picross_Unlimited.Api.Dtos;

namespace Picross_Unlimited.Api.Controllers
    {
        [Route("[controller]")]
        [ApiController]
        public class TokenController : ControllerBase
        {
            public AppDbContext _context;
            public UserManager<AppUser> _userManager;
            public JwtConfiguration _jwtConfiguration;
            public RoleManager<IdentityRole> _roleManager;
            public TokenController(AppDbContext context, UserManager<AppUser> userManager, JwtConfiguration jwtConfiguration, RoleManager<IdentityRole> roleManager)
            {
                _context = context;
                _userManager = userManager;
                _jwtConfiguration = jwtConfiguration;
                _roleManager = roleManager;
            }

            [HttpPost("GetToken")]
            public async Task<IActionResult> GetToken([FromBody] UserCredentialsDto userCredentials)
            {
                if (string.IsNullOrEmpty(userCredentials.Username))
                {
                    return BadRequest("Username is required");
                }
                if (string.IsNullOrEmpty(userCredentials.Password))
                {
                    return BadRequest("Password is required");
                }

                var user = _context.Users.FirstOrDefault(u => u.UserName == userCredentials.Username);

                if (user is null) { return Unauthorized("The user account was not found"); }

                // Verify the user's password - Microsoft will do this for us. 
                bool results = await _userManager.CheckPasswordAsync(user, userCredentials.Password);
                if (results)
                {
                    // Set up our security key and our hashing algorithm
                    // PS we are storing our key in a pretty unsafe area... Do not store your JWT config key as plain text like this in production level applications\
                    // If someone gets this token secret they can generate tokens for themselves
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>
                    {
                    new(JwtRegisteredClaimNames.Sub, user.UserName!),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new("userId", user.Id.ToString()),
                    new("email", user.UserName!.ToString()), 
                    };

                    // Retrieve all roles associated with the user
                    var roles = await _userManager.GetRolesAsync(user);
                    var userClaims = await _userManager.GetClaimsAsync(user);
                    claims.AddRange(userClaims.Where(claim => claim.Type != null && claim.Value != null).Select(claim => new Claim(claim.Type, claim.Value)));

                    // Iterate over each role
                    foreach (var role in roles)
                    {
                        // Add a role claim to the claims list
                        claims.Add(new Claim(ClaimTypes.Role, role));

                        // Find the role object and retrieve all claims associated with it
                        var roleClaims = await _roleManager.GetClaimsAsync(
                            _roleManager.Roles.First(f => f.Name == role)
                        );

                        // Add each role-specific claim to the claims list
                        claims.AddRange(roleClaims
                            .Where(claim => claim.Type != null && claim.Value != null)
                            .Select(claim => new Claim(claim.Type, claim.Value))
                        );
                    }

                    var token = new JwtSecurityToken(
                        issuer: _jwtConfiguration.Issuer,
                        audience: _jwtConfiguration.Audience,
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(_jwtConfiguration.ExpirationInMinutes),
                        signingCredentials: credentials
                    );
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new { token = jwtToken });
                }
                return Unauthorized("The username or password is incorrect"); // When do we give info back to the user? Pros/Cons?
            }
        }
    }

