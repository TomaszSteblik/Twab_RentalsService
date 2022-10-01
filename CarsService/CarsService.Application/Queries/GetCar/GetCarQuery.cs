using CarsService.Application.DTOs;
using MediatR;

namespace CarsService.Application.Queries.GetCar;

public class GetCarQuery : IRequest<ReadCarDto>
{
    public Guid Id { get; set; }

    public GetCarQuery(Guid id)
    {
        Id = id;
    }
}