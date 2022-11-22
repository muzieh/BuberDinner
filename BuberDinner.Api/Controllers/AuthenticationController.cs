using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{

    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest loginRequest) {
        return Ok(loginRequest);
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Reqister([FromBody] RegisterRequest registerRequest)
    {
        return Ok(registerRequest);
    }
}