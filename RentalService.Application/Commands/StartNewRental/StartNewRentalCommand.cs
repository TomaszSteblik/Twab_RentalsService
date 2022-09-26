using MediatR;
using RentalService.Application.DTOs;

namespace RentalService.Application.Commands.StartNewRental;

public class StartNewRentalCommand : IRequest
{
    public StartNewRentalCommand(AddRentalDto rentalInfo)
    {
        RentalInfo = rentalInfo;
    }

    public AddRentalDto RentalInfo { get; set; }
}