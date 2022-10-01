using CarsService.Infrastructure.DAOs;
using Microsoft.EntityFrameworkCore;

namespace CarsService.Infrastructure.EF;

public class CarsServiceContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    public CarsServiceContext(DbContextOptions<CarsServiceContext> options) : base(options)
    {
        
    }
}