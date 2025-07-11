using BlogApp.Business.DTOs.User;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromForm] RegisterDto dto)
    {
        try
        {
            await _userService.Register(dto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromForm] LoginDto dto)
    {
        try
        {

            return Ok(await _userService.Login(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}