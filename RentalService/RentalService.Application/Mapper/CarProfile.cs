using AutoMapper;
using RentalService.Application.DTOs;
using RentalService.Core.Entities;

namespace RentalService.Application.Mapper;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, GetCarDto>().ReverseMap();
    }
}