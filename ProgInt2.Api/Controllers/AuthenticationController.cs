using Microsoft.AspNetCore.Mvc;
using ProgInt2.Contracts.Authentication;
using ProgInt2.Application.Services.Authentication;
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
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
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
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );
        
        return Ok(response);
    }

    [HttpPost("change-password")]
    public IActionResult ChangePassword(ChangePasswordRequest request)
    {
         var authResult = _authenticationService.ChangePassword(            
            Guid.Parse(request.Id),
            request.NewPassword
        );    

        var response = new AuthenticationResponse
        (
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );

        return Ok(response);
    }

}