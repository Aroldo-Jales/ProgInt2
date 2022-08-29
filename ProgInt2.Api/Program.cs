using ProgInt2.Application.Services.Authentication;
using ProgInt2.Infrastructure;
using ProgInt2.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services    
        .AddApplication()
        .AddInfrastructure(builder.Configuration);            
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
