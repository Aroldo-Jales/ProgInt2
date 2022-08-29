using ProgInt2.Application.Helpers.Authentication;
using ProgInt2.Application.Common.Interfaces.Authentication;
using ProgInt2.Application.Common.Interfaces.Persistence;
using ProgInt2.Domain.Entities;
using ProgInt2.Application.Common.Errors.Authentication;

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

        if(_userRepository.GetUserByEmail(email) is User user && user.Password == password)
        {
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,          
                token
            );
        }
        else
        {
            throw new Exception("Invalid credentials");
        }
    }

    public AuthenticationResult SignUp(string firstName, string lastName, string email, string password)
    {   
        if(_userRepository.GetUserByEmail(email) is not User)
        {
            if(Validation.IsValidEmail(email))
            {
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
            else
            {
                throw new InvalidEmailException();
            }    
        }
        else
        {
            throw new DuplicateEmailException();  
        }        
    }

    public AuthenticationResult ChangePassword(Guid id, string password)
    {
        if(_userRepository.GetUserById(id) is User user)
        {
            if(Validation.IsValidPassword(password))
            {                    

                user.Password = password;

                _userRepository.Update(user);

                var token = _jwtTokenGenerator.GenerateToken(user);

                return new AuthenticationResult(
                    user,             
                    token
                );
            }
            else
            {
                throw new InvalidPasswordException();    
            }
        }
        else
        {
            throw new UserNotFoundException();
        }
    }
}