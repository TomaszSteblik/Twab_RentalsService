using CarsService.Application.DTOs;
using MediatR;

namespace CarsService.Application.Queries.GetUserCars;

public class GetUserCarsQuery : IRequest<IEnumerable<ReadCarDto>>
{
    public Guid UserId { get; set; }

    public GetUserCarsQuery(Guid userId)
    {
        UserId = userId;
    }
}