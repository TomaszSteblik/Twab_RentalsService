using MediatR;
using UsersService.Application.DTOs;

namespace UsersService.Application.Commands.AddUser;

public class AddUserCommand : IRequest
{
    public AddUserDto UserToAdd { get; set; }

    public AddUserCommand(AddUserDto userToAdd)
    {
        UserToAdd = userToAdd;
    }
}