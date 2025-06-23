
using Microsoft.AspNetCore.Mvc;
using SpendCent.Core.DTOs;
using SpendCent.Core.ServiceContracts;

namespace SpendCent.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
   private readonly IUsersService _usersService;
    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration request!");
        }

        var response = await _usersService.Register(registerRequest);


        if (response == null || response.Success == false)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("Invalid login request.");
        }
        var response = await _usersService.Login(loginRequest);

        if (response == null || response.Success == false)
        {
            return Unauthorized("Invalid email or password.");
        }
        return Ok(response);
    }
}

