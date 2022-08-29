using System.Net;
using System.Text.Json;
using ProgInt2.Application.Common.Errors.Authentication;

namespace ProgInt2.Api.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, (IServiceException) ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, IServiceException exception)
    {
        var code = exception.StatusCode;
        
        var result = JsonSerializer.Serialize(new { 
                title = "An error occurred.",                                                                
                type = exception.GetType().Name,
                detail = exception.ErrorMessage,                
                status = exception.StatusCode,
                traceId= context.TraceIdentifier
        });
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}