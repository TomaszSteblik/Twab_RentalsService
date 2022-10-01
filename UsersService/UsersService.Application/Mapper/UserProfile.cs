using AutoMapper;
using UsersService.Application.DTOs;
using UsersService.Core.Entities;

namespace UsersService.Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, ReadUserDto>()
            .ForMember(dest => dest.BirthDate, 
                opt => opt.MapFrom(
                    src => src.BirthDate.ToDateTime(TimeOnly.MinValue)));
    }
}