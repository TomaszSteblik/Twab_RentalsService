using AutoMapper;
using UsersService.Core.Entities;

namespace UsersService.Infrastructure.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, DAOs.User>()
            .ForMember(userDb => userDb.ProfilePictureBase64, 
                opt => opt.MapFrom(
                    user => Convert.ToBase64String(user.ProfilePicture)))
            .ForMember(dest => dest.Id, 
                opt => opt.MapFrom(
                    src => src.Id.ToString()))
            .ForMember(dest => dest.BirthDate,
                opt => opt.MapFrom(
                    src => src.BirthDate.ToDateTime(TimeOnly.MinValue)));
        CreateMap<DAOs.User, User>()
            .ForMember(user => user.ProfilePicture, 
                opt => opt.MapFrom(
                    userDb => Convert.FromBase64String(userDb.ProfilePictureBase64)))
            .ForMember(dest => dest.Id, 
                opt => opt.MapFrom(
                    src => Guid.Parse(src.Id)))
            .ForMember(dest => dest.BirthDate,
                opt => opt.MapFrom(
                    src => DateOnly.FromDateTime(src.BirthDate)));
    }
}