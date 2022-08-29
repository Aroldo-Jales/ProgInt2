using System.Net;

namespace ProgInt2.Application.Common.Errors.Authentication
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
        
    }
}