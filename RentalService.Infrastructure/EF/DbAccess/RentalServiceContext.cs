using Microsoft.EntityFrameworkCore;
using RentalService.Infrastructure.DAOs;

namespace RentalService.Infrastructure.EF.DbAccess;

public class RentalServiceContext : DbContext
{
    public DbSet<Rental> Rentals{ get; set; }
    public DbSet<Car> Cars { get; set; }

    public RentalServiceContext(DbContextOptions<RentalServiceContext> opt) : base(opt)
    {
        
    }
}