using RentalService.Core.Entities;

namespace RentalService.Core.Repositories;

public interface ICarsRepository
{
    Task<Car> GetCarById(Guid guid);
    Task<IEnumerable<Car>> GetAvailableCars();
    Task UpdateAsync(Car car);
}