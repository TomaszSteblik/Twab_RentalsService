using CarsService.Core.Repositories;
using CarsService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarsService.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICarsRepository, CarsRepository>();
    }
}