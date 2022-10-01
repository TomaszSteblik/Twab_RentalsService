using MediatR;

namespace RentalService.Application.Commands.EndRental;

public class EndRentalCommand : IRequest
{
    public Guid RentalId { get; set; }

    public EndRentalCommand(Guid rentalId)
    {
        RentalId = rentalId;
    }
}