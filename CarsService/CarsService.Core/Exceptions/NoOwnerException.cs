using System.Net;

namespace CarsService.Core.Exceptions;

public class NoOwnerException : DomainException
{
    public NoOwnerException(string message) : base(message)
    {
    }

    public override string ErrorCode => "no_owner_exception";
    public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;
}