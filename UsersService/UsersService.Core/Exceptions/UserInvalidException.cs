using System.Net;

namespace UsersService.Core.Exceptions;

public class UserInvalidException : DomainException
{
    public UserInvalidException(string message) : base(message)
    {
    }

    public override string ErrorCode => "invalid_user_data_exception";
    public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;
}