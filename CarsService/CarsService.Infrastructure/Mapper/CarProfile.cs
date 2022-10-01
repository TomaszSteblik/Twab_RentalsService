using AutoMapper;
using CarsService.Core.Entities;

namespace CarsService.Infrastructure.Mapper;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, DAOs.Car>()
            .ForMember(carDb => carDb.PictureBase64, opt => 
                opt.MapFrom(car=>Convert.ToBase64String(car.Picture)));
        CreateMap<DAOs.Car, Car>()
            .ForMember(car => car.Picture, opt => 
                opt.MapFrom(carDb=>Convert.FromBase64String(carDb.PictureBase64)));
    }
}