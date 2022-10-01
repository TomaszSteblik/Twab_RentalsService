using System.Net;

namespace UsersService.Core.Exceptions;

public abstract class DomainException : ApplicationException
{
    public abstract string ErrorCode { get; }
    public abstract HttpStatusCode StatusCode { get; }

    protected DomainException(string message) : base(message)
    {
    }
}