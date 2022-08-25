using ProgInt2.Domain.Entities;
namespace ProgInt2.Application.Services.Authentication;

public record AuthenticationResult(
    User user,    
    string Token
);