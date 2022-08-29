using System.Net;
using System.Text.Json;

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
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        
        var result = JsonSerializer.Serialize(new { 
                title = "An error occurred.",                                                                
                type = "Internal server error.",
                detail = exception.Message,                
                status = (int) code,
                traceId= context.TraceIdentifier
        });
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}