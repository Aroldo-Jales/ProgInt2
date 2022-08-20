namespace ProgInt2.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult SignIn(string email, string password);
    AuthenticationResult SignUp(string firstName, string lastName, string email, string password);
}