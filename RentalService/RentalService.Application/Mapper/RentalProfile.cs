using AutoMapper;
using RentalService.Application.DTOs;
using RentalService.Core.Entities;

namespace RentalService.Application.Mapper;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<GetRentalDto, Rental>().ReverseMap();
    }
}