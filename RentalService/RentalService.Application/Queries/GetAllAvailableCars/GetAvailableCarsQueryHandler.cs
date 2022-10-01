using AutoMapper;
using MediatR;
using RentalService.Application.DTOs;
using RentalService.Core.Repositories;

namespace RentalService.Application.Queries.GetAllAvailableCars;

internal class GetAvailableCarsQueryHandler : IRequestHandler<GetAvailableCarsQuery, IEnumerable<GetCarDto>>
{
    private readonly ICarsRepository _carsRepository;
    private readonly IMapper _mapper;

    public GetAvailableCarsQueryHandler(ICarsRepository carsRepository, IMapper mapper)
    {
        _carsRepository = carsRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetCarDto>> Handle(GetAvailableCarsQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<GetCarDto>>(await _carsRepository.GetAvailableCars());
    }
}