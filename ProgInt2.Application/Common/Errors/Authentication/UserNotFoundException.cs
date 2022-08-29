using System.Net;

namespace ProgInt2.Application.Common.Errors.Authentication;

public class UserNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "User not found.";
}