using MediatR;
using RentalService.Application.DTOs;

namespace RentalService.Application.Queries.GetAllAvailableCars;

public class GetAvailableCarsQuery : IRequest<IEnumerable<GetCarDto>>
{
    
}