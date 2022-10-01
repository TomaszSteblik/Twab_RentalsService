using MediatR;
using UsersService.Application.DTOs;

namespace UsersService.Application.Queries.GetUser;

public class GetUserQuery : IRequest<ReadUserDto>
{
    public Guid UserId { get; set; }

    public GetUserQuery(Guid userId)
    {
        UserId = userId;
    }
}