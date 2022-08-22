using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProgInt2.Application.Common.Interfaces.Authentication;
using ProgInt2.Application.Common.Interfaces.Services;

namespace ProgInt2.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _datetimeprovider;

        public JwtTokenGenerator(IDateTimeProvider datetimeprovider, IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
            _datetimeprovider = datetimeprovider;            
        }
        public string GenerateToken(Guid id, string firstName, string lastName)
        {

            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                    SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, firstName + " " + lastName),                
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),                
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),  
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _datetimeprovider.UtcNow.AddDays(_jwtSettings.ExpireDays),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}