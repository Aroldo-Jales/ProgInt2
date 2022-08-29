using System.Net;

namespace ProgInt2.Application.Common.Errors.Authentication;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists.";
}