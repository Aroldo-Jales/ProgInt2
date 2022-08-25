using ProgInt2.Domain.Entities;
namespace ProgInt2.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}