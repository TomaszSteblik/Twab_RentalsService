using AutoMapper;
using RentalService.Infrastructure.DAOs;

namespace RentalService.Infrastructure.Mapper;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<Core.Entities.Rental, Rental>()
            .ForMember(x=>x.Car,opt => opt.Ignore())
            .ForMember(x=>x.CarId, opt
                => opt.MapFrom(z=>z.Car.Id)).ReverseMap();
    }
}