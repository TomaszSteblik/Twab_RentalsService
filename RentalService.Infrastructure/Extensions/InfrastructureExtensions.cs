using Microsoft.Extensions.DependencyInjection;
using RentalService.Core.Repositories;
using RentalService.Infrastructure.Repositories;

namespace RentalService.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IRentalsRepository, RentalsRepository>();
        services.AddScoped<ICarsRepository, CarsRepository>();
    }
}