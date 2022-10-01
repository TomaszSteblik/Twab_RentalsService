using System.Net;

namespace CarsService.Core.Exceptions;

public class InvalidCarModelException : DomainException
{
    public InvalidCarModelException(string message) : base(message)
    {
    }

    public override string ErrorCode => "invalid_car_model_exception";
    public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;
}