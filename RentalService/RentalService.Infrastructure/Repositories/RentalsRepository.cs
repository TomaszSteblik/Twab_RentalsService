using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentalService.Core.Entities;
using RentalService.Core.Repositories;
using RentalService.Infrastructure.EF.DbAccess;

namespace RentalService.Infrastructure.Repositories;

public class RentalsRepository : IRentalsRepository
{
    private readonly RentalServiceContext _context;
    private readonly IMapper _mapper;

    public RentalsRepository(RentalServiceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task CreateRental(Rental rental)
    {
        var entity = _mapper.Map<DAOs.Rental>(rental);
        
        await _context.Rentals.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Rental> GetRentalById(Guid guid)
    {
        var rental = await _context.Rentals
            .Include(x=>x.Car)
            .FirstOrDefaultAsync(x=>x.Id == guid);
        return _mapper.Map<Rental>(rental);
    }

    public async Task<IEnumerable<Rental>> GetUserRentals(Guid userId)
    {
        var rentals = await _context.Rentals
            .Include(x => x.Car)
            .Where(x=>x.Id == userId)
            .ToListAsync();
        return _mapper.Map<IEnumerable<Rental>>(rentals);
    }

    public async Task UpdateAsync(Rental rental)
    {
        var dbRental = await _context.Rentals.FindAsync(rental.Id);
        dbRental.DateTimeFrom = rental.DateTimeFrom;
        dbRental.DateTimeToActual = rental.DateTimeToActual;
        dbRental.DateTimeToDeclared = rental.DateTimeToDeclared;
        dbRental.CarId = rental.Car.Id;
        await _context.SaveChangesAsync();
    }
}