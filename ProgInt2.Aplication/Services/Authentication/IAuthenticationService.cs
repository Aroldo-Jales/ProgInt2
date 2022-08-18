namespace ProgInt2.Aplication.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult SignIn(string email, string password);
    AuthenticationResult SignUp(string firstName, string lastName, string email, string password);
}