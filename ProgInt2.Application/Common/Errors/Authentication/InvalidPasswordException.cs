using System.Net;

namespace ProgInt2.Application.Common.Errors.Authentication;

public class InvalidPasswordException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "Password is invalid.";
}