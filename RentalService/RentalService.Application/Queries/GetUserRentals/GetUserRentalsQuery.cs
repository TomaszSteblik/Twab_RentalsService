using MediatR;
using RentalService.Application.DTOs;

namespace RentalService.Application.Queries.GetUserRentals;

public class GetUserRentalsQuery : IRequest<IEnumerable<GetRentalDto>>
{
    public Guid UserId { get; set; }

    public GetUserRentalsQuery(Guid userId)
    {
        UserId = userId;
    }
}