using Microsoft.Extensions.DependencyInjection;

namespace ProgInt2.Application.Services.Authentication;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}