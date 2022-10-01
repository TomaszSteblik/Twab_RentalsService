using CarsService.Core.Entities;

namespace CarsService.Core.Repositories;

public interface ICarsRepository
{
    Task<Car> GetCarById(Guid id);
    Task<bool> AddCar(Car car);
    Task<IEnumerable<Car>> GetCarsByOwnerId(Guid id);
}