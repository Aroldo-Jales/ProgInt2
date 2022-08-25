using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using ProgInt2.Application.Common.Interfaces.Authentication;
using ProgInt2.Application.Common.Interfaces.Services;
using ProgInt2.Application.Common.Interfaces.Persistence;

using ProgInt2.Infrastructure.Authentication;
using ProgInt2.Infrastructure.Services;
using ProgInt2.Infrastructure.Persistence;

using ProgInt2.Infrastructure.Database;

namespace ProgInt2.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<AppDbContext>();

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));        
        //Application interfaces with infra implementation
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();    
        services.AddScoped<IUserRepository, UserRepository>();        

        return services;
    }
}