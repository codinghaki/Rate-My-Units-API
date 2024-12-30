using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rate_My_Units_API.Dtos.Account;
using Rate_My_Units_API.Interfaces;
using Rate_My_Units_API.Models;
using Rate_My_Units_API.Services;

namespace Rate_My_Units_API.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;
    
    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        this._userManager = userManager;
        this._tokenService = tokenService;
        this._signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username.ToLower());

        if (user == null)
        {
            return Unauthorized("Invalid username");
        }
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded)
        {
            return Unauthorized("Username not found or password is incorrect");
        }

        return Ok(new NewUserDto(
            user.UserName,
            user.Email,
            _tokenService.CreateToken(user)));
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
                    return Ok(
                        new NewUserDto
                        (
                            appUser.UserName,
                            registerDto.Email,
                            _tokenService.CreateToken(appUser)
                        ));
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