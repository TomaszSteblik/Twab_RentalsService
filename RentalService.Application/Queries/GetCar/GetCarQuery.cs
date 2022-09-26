using MediatR;
using RentalService.Application.DTOs;

namespace RentalService.Application.Queries.GetCar;

public class GetCarQuery : IRequest<GetCarDto>
{
    public Guid Id { get; set; }

    public GetCarQuery(Guid id)
    {
        Id = id;
    }
}