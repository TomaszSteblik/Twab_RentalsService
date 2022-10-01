using AutoMapper;
using CarsService.Application.DTOs;
using CarsService.Core.Entities;

namespace CarsService.Application.Mapper;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<WriteCarDto, Car>()
            .ForMember(car => car.DollarsPerHour, 
                opt => opt.MapFrom(dto => dto.DollarsPerHour));
        CreateMap<Car, ReadCarDto>();
    }
}