using AutoMapper;
using MediatR;
using RentalService.Application.DTOs;
using RentalService.Core.Repositories;

namespace RentalService.Application.Queries.GetRental;

internal class GetRentalQueryHandler : IRequestHandler<GetRentalQuery, GetRentalDto>
{
    private readonly IMapper _mapper;
    private readonly IRentalsRepository _rentalsRepository;

    public GetRentalQueryHandler(IMapper mapper, IRentalsRepository rentalsRepository)
    {
        _mapper = mapper;
        _rentalsRepository = rentalsRepository;
    }
    
    public async Task<GetRentalDto> Handle(GetRentalQuery request, CancellationToken cancellationToken)
    {
        var rental = await _rentalsRepository.GetRentalById(request.RentalId);
        return _mapper.Map<GetRentalDto>(rental);
    }
}