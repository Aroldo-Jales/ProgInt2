using Microsoft.AspNetCore.Mvc;
using ProgInt2.Contracts.Authentication;
using ProgInt2.Aplication.Services.Authentication;
namespace ProgInt2.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{    
    private readonly IAuthenticationService _authenticationService;
    
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("signup")]
    public IActionResult SignUp(SignUpRequest request)
    {
        var authResult = _authenticationService.SignUp(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse
        (
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("signin")]   
    public IActionResult SignIn(SignInRequest request)
    {
         var authResult = _authenticationService.SignIn(            
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse
        (
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );
        
        return Ok(response);
    }

}