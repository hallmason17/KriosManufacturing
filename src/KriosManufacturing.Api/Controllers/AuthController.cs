namespace KriosManufacturing.Api;

using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;

using KriosManufacturing.Core.Services;

using Microsoft.AspNetCore.Mvc;

[Route("api/v1/[controller]")]
[ApiController]
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
public class AuthController(AuthService authService) : ControllerBase
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
{
    private readonly AuthService authService = authService;

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login(AccountLoginRequest credentials, CancellationToken ctok)
    {
        var cookieOpts = new CookieOptions()
        {
            Secure = true,
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddMinutes(20),
        };

        if (await this.authService.AuthenticateAsync(credentials.Email, credentials.Password, ctok))
        {
            Response.Cookies.Append("test", "hello world", cookieOpts);
            return Ok();
        }

        return BadRequest();
    }
}

public record AccountLoginRequest(string Email, string Password) { }
