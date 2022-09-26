using MediatR;
using RentalService.Core.Repositories;

namespace RentalService.Application.Commands.EndRental;

internal class EndRentalCommandHandler : IRequestHandler<EndRentalCommand>
{
    private readonly IRentalsRepository _rentalsRepository;
    private readonly ICarsRepository _carsRepository;

    public EndRentalCommandHandler(IRentalsRepository rentalsRepository, ICarsRepository carsRepository)
    {
        _rentalsRepository = rentalsRepository;
        _carsRepository = carsRepository;
    }
    
    public async Task<Unit> Handle(EndRentalCommand request, CancellationToken cancellationToken)
    {
        var rental = await _rentalsRepository.GetRentalById(request.RentalId);
        rental.EndRental();
        await _rentalsRepository.UpdateAsync(rental);
        await _carsRepository.UpdateAsync(rental.Car);
        //TODO: Send info about payment to message broker -> payment service
        return Unit.Value;
    }
}