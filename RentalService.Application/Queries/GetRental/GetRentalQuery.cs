using MediatR;
using RentalService.Application.DTOs;

namespace RentalService.Application.Queries.GetRental;

public class GetRentalQuery : IRequest<GetRentalDto>
{
    public Guid RentalId { get; set; }

    public GetRentalQuery(Guid rentalId)
    {
        RentalId = rentalId;
    }
}