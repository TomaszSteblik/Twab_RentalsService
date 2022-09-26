using AutoMapper;
using MediatR;
using RentalService.Application.DTOs;
using RentalService.Core.Repositories;

namespace RentalService.Application.Queries.GetUserRentals;

internal class GetUserRentalsQueryHandler : IRequestHandler<GetUserRentalsQuery, IEnumerable<GetRentalDto>>
{
    private readonly IMapper _mapper;
    private readonly IRentalsRepository _rentalsRepository;

    public GetUserRentalsQueryHandler(IMapper mapper, IRentalsRepository rentalsRepository)
    {
        _mapper = mapper;
        _rentalsRepository = rentalsRepository;
    }
    public async Task<IEnumerable<GetRentalDto>> Handle(GetUserRentalsQuery request, CancellationToken cancellationToken)
    {
        var rentals = await _rentalsRepository.GetUserRentals(request.UserId);
        return _mapper.Map<IEnumerable<GetRentalDto>>(rentals);
    }
}