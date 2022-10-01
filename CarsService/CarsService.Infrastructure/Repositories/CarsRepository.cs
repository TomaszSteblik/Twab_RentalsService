using AutoMapper;
using CarsService.Core.Entities;
using CarsService.Core.Repositories;
using CarsService.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CarsService.Infrastructure.Repositories;

public class CarsRepository : ICarsRepository
{
    private readonly CarsServiceContext _context;
    private readonly IMapper _mapper;

    public CarsRepository(CarsServiceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Car> GetCarById(Guid id)
    {
        var carDao = await _context.Cars.FindAsync(id);
        return _mapper.Map<Car>(carDao);
    }

    public async Task<bool> AddCar(Car car)
    {
        var carDao = _mapper.Map<DAOs.Car>(car);
        await _context.AddAsync(carDao);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<Car>> GetCarsByOwnerId(Guid id)
    {
        var carsDao = await _context.Cars.Where(car => car.OwnerId == id).ToListAsync();
        return _mapper.Map<IEnumerable<Car>>(carsDao);
    }
}