using CarsService.Application.DTOs;
using MediatR;

namespace CarsService.Application.Commands.AddCar;

public class AddCarCommand : IRequest
{
    public WriteCarDto CarToAdd { get; set; }

    public AddCarCommand(WriteCarDto carToAdd)
    {
        CarToAdd = carToAdd;
    }
}