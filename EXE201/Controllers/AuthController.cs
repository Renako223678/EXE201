using Microsoft.AspNetCore.Mvc;

using EXE201.Services;
using EXE201.Controllers.DTO;

namespace EXE201.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO loginDto)
    {
        var token = _authService.Authenticate(loginDto);
        if (token == null)
        {
            return Unauthorized(new { message = "Invalid username or password" });
        }

        return Ok(new { message = "Login successful", token });
    }
}
