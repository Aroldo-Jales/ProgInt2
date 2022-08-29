using System.Net;

namespace ProgInt2.Application.Common.Errors.Authentication;

public class InvalidEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email is invalid.";
}