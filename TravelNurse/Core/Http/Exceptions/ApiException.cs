using System.Net;

namespace Core.Http.Exceptions;

public class ApiException : AutoWrapper.Wrappers.ApiException
{
    public ApiException(string message, 
        HttpStatusCode statusCode,
        string? errorCode = null,
        string? refLink = null): base(message, (int) statusCode, errorCode, refLink) { }


    public ApiException(object customError, HttpStatusCode statusCode) : base(customError, (int) statusCode) {}

    public HttpStatusCode StatusCode
    {
        get
        {
            return (HttpStatusCode) base.StatusCode;
        }
    }
}