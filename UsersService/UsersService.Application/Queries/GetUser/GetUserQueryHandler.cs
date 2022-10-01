using AutoMapper;
using MediatR;
using UsersService.Application.DTOs;
using UsersService.Core.Repositories;

namespace UsersService.Application.Queries.GetUser;

internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, ReadUserDto>
{
    private readonly IMapper _mapper;
    private readonly IUsersRepository _usersRepository;

    public GetUserQueryHandler(IMapper mapper, IUsersRepository usersRepository)
    {
        _mapper = mapper;
        _usersRepository = usersRepository;
    }
    
    public async Task<ReadUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetUserById(request.UserId);
        return _mapper.Map<ReadUserDto>(user);
    }
}