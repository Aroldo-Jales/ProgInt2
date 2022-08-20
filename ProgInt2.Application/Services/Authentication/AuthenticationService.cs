using ProgInt2.Application.Common.Interfaces.Authentication;

namespace ProgInt2.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{   
    private readonly IJwtTokenGenerator _jwtTokenGenerator; 

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult SignIn(string email, string password)
    {               
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "firstName",
            "lastName",
            email,             
            "token"
        );
    }

    public AuthenticationResult SignUp(string firstName, string lastName, string email, string password)
    {        
        Guid id = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(id, firstName, lastName); 

        return new AuthenticationResult(
            id, 
            firstName, 
            lastName, 
            email,             
            token
        );
    }
}