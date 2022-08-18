namespace ProgInt2.Contracts.Authentication;

public record SignInRequest(    
    string Email,
    string Password
);