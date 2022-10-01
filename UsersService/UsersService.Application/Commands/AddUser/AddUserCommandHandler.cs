using AutoMapper;
using MediatR;
using UsersService.Core.Entities;
using UsersService.Core.Repositories;

namespace UsersService.Application.Commands.AddUser;

internal class AddUserCommandHandler : IRequestHandler<AddUserCommand>
{ 
    private readonly IUsersRepository _usersRepository;

    public AddUserCommandHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            request.UserToAdd.FirstName,
            request.UserToAdd.LastName,
            DateOnly.Parse(
                $"{request.UserToAdd.BirthDateYear}/{request.UserToAdd.BirthDateMonth}/{request.UserToAdd.BirthDateDay}"),
            request.UserToAdd.Email,
            request.UserToAdd.Password,
            request.UserToAdd.Username,
            request.UserToAdd.ProfilePicture);
        user.Validate();
        await _usersRepository.AddUser(user);
        return Unit.Value;
    }
}