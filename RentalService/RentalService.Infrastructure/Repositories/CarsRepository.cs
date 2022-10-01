using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentalService.Core.Entities;
using RentalService.Core.Repositories;
using RentalService.Infrastructure.EF.DbAccess;

namespace RentalService.Infrastructure.Repositories;

public class CarsRepository : ICarsRepository
{
    private readonly RentalServiceContext _context;
    private readonly IMapper _mapper;

    public CarsRepository(RentalServiceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Car> GetCarById(Guid guid)
    {
        var car = await _context.Cars.FindAsync(guid);
        return _mapper.Map<Car>(car);
    }

    public async Task<IEnumerable<Car>> GetAvailableCars()
    {
        var cars = await _context.Cars.Where(x=>!x.IsRented).ToListAsync();
        return _mapper.Map<IEnumerable<Car>>(cars);
    }

    public async Task UpdateAsync(Car car)
    {
        var dbCar = await _context.Cars.FindAsync(car.Id);
        dbCar.Model = car.Model;
        dbCar.IsRented = car.IsRented;
        dbCar.DollarsPerHours = car.DollarsPerHour;
        await _context.SaveChangesAsync();
    }
}