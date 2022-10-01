using AutoMapper;
using CarsService.Application.DTOs;
using CarsService.Core.Repositories;
using MediatR;

namespace CarsService.Application.Queries.GetUserCars;

public class GetUserCarsQueryHandler : IRequestHandler<GetUserCarsQuery, IEnumerable<ReadCarDto>>
{
    private readonly IMapper _mapper;
    private readonly ICarsRepository _carsRepository;

    public GetUserCarsQueryHandler(IMapper mapper, ICarsRepository carsRepository)
    {
        _mapper = mapper;
        _carsRepository = carsRepository;
    }
    
    public async Task<IEnumerable<ReadCarDto>> Handle(GetUserCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carsRepository.GetCarsByOwnerId(request.UserId);
        return _mapper.Map<IEnumerable<ReadCarDto>>(cars);
    }
}