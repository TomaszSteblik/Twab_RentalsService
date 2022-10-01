using AutoMapper;
using CarsService.Application.DTOs;
using CarsService.Core.Repositories;
using MediatR;

namespace CarsService.Application.Queries.GetCar;

public class GetCarQueryHandler : IRequestHandler<GetCarQuery, ReadCarDto>
{
    private readonly IMapper _mapper;
    private readonly ICarsRepository _carsRepository;

    public GetCarQueryHandler(IMapper mapper, ICarsRepository carsRepository)
    {
        _mapper = mapper;
        _carsRepository = carsRepository;
    }
    
    public async Task<ReadCarDto> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        var car = await _carsRepository.GetCarById(request.Id);
        return _mapper.Map<ReadCarDto>(car);
    }
}