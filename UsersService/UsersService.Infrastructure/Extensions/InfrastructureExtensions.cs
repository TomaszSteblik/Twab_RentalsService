using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using UsersService.Core.Repositories;
using UsersService.Infrastructure.Repositories;

namespace UsersService.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClient, MongoClient>(s =>
            new MongoClient(s.GetRequiredService<IConfiguration>()["MongoConnectionString"]));
        services.AddScoped<IUsersRepository, UsersRepository>();
    }
}