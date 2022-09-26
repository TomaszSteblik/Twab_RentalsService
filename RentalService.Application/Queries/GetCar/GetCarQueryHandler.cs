using AutoMapper;
using MediatR;
using RentalService.Application.DTOs;
using RentalService.Core.Repositories;

namespace RentalService.Application.Queries.GetCar;

internal class GetCarQueryHandler : IRequestHandler<GetCarQuery, GetCarDto>
{
    private readonly ICarsRepository _carsRepository;
    private readonly IMapper _mapper;

    public GetCarQueryHandler(ICarsRepository carsRepository, IMapper mapper)
    {
        _carsRepository = carsRepository;
        _mapper = mapper;
    }
    
    public async Task<GetCarDto> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<GetCarDto>(await _carsRepository.GetCarById(request.Id));
    }
}