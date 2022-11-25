using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        // Check if user already registered
        
        // Create a new user (generate unique ID)
        var result = _authenticationService.Register(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

            
        var response =
            new AuthenticationResult(result.Id, result.FirstName, result.LastName, result.Email, result.Token);
        return Ok(response);
    }
    

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = _authenticationService.Login(
            request.Email,
            request.Password);
        var response =
            new AuthenticationResult(result.Id, result.FirstName, result.LastName, result.Email, result.Token); 
        return Ok(response);
    }

}