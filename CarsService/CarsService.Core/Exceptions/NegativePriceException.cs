using System.Net;

namespace CarsService.Core.Exceptions;

public class NegativePriceException : DomainException
{
    public NegativePriceException(string message) : base(message)
    {
    }

    public override string ErrorCode => "negative_price_exception";
    public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;
}