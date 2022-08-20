namespace ProgInt2.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid id, string firstname, string lastname);
    }
}