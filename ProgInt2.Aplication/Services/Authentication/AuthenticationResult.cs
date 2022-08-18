namespace ProgInt2.Aplication.Services.Authentication;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,    
    string Token
);