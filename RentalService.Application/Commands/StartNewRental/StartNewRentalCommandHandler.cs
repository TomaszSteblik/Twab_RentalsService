using MediatR;
using RentalService.Core.Entities;
using RentalService.Core.Repositories;

namespace RentalService.Application.Commands.StartNewRental;

internal class StartNewRentalCommandHandler : IRequestHandler<StartNewRentalCommand>
{
    private readonly ICarsRepository _carsRepository;
    private readonly IRentalsRepository _rentalsRepository;

    public StartNewRentalCommandHandler(ICarsRepository carsRepository, IRentalsRepository rentalsRepository)
    {
        _carsRepository = carsRepository;
        _rentalsRepository = rentalsRepository;
    }
    
    public async Task<Unit> Handle(StartNewRentalCommand request, CancellationToken cancellationToken)
    {
        var car = await _carsRepository.GetCarById(request.RentalInfo.CarId);
        var rental = new Rental(DateTime.Now.AddMinutes(request.RentalInfo.RentalTimeInMinutes), car, 
            request.RentalInfo.UserId);
        rental.StartRental();
        await _carsRepository.UpdateAsync(rental.Car);
        await _rentalsRepository.CreateRental(rental);
        return Unit.Value;
    }
}