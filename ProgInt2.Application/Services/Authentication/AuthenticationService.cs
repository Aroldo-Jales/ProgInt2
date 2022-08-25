using ProgInt2.Application.Common.Interfaces.Authentication;
using ProgInt2.Application.Common.Interfaces.Persistence;
using ProgInt2.Domain.Entities;

namespace ProgInt2.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{   
    private readonly IJwtTokenGenerator _jwtTokenGenerator; 
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult SignIn(string email, string password)
    {            
        // Change implementation to uses hash email+password in database

        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("");
        }

        if(user.Password != password)
        {
            throw new Exception("Invalid credentials");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,          
            token
        );
    }

    public AuthenticationResult SignUp(string firstName, string lastName, string email, string password)
    {   
        if(_userRepository.GetUserByEmail(email) != null)
        {
            throw new Exception("User already exists.");
        }

        var user = new User
        (
            firstName, 
            lastName, 
            email, 
            password
        );
        
        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user); 

        return new AuthenticationResult(
            user,             
            token
        );        
    }
}