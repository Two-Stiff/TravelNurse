using System.Net;

namespace Core.Http.Exceptions;

public class NotFoundException : ApiException
{
    public NotFoundException(string message) : base(message, HttpStatusCode.NotFound){}
    
}

public class NotFoundException<T> : NotFoundException
{
    public NotFoundException(string? message = null) : base(message ?? GetDefaultErrorMessage()) {}

    private static string GetDefaultErrorMessage()
    {
        return $"{typeof(T).Name} not found";
    }
}