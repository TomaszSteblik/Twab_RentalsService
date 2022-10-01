using AutoMapper;
using CarsService.Core.Entities;
using CarsService.Core.Repositories;
using MediatR;

namespace CarsService.Application.Commands.AddCar;

public class AddCarCommandHandler : IRequestHandler<AddCarCommand>
{
    private readonly IMapper _mapper;
    private readonly ICarsRepository _carsRepository;

    public AddCarCommandHandler(IMapper mapper, ICarsRepository carsRepository)
    {
        _mapper = mapper;
        _carsRepository = carsRepository;
    }
    
    public async Task<Unit> Handle(AddCarCommand request, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<Car>(request.CarToAdd);
        car.Validate();
        await _carsRepository.AddCar(car);
        return Unit.Value;
    }
}