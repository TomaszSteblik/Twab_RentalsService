using AutoMapper;
using RentalService.Core.Entities;

namespace RentalService.Infrastructure.Mapper;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, DAOs.Car>().ReverseMap();
    }
}