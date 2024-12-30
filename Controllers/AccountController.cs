using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rate_My_Units_API.Dtos.Account;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    
    private readonly UserManager<AppUser> _userManager;
    
    public AccountController(UserManager<AppUser> userManager)
    {
        this._userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            // Verify DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Create a new AppUser object
            var appUser = new AppUser()
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };
            // Attempt to add the user to db, let usermanager validate
            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            // If creating user succeeded...
            if (createdUser.Succeeded)
            {
                // Add newly created user object to the user role
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                if (roleResult.Succeeded)
                {
                    return Ok("User created");
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }

        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}