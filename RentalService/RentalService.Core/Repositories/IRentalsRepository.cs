using RentalService.Core.Entities;

namespace RentalService.Core.Repositories;

public interface IRentalsRepository
{
    Task CreateRental(Rental rental);
    Task<Rental> GetRentalById(Guid guid);
    Task<IEnumerable<Rental>> GetUserRentals(Guid userId);
    Task UpdateAsync(Rental rental);
}