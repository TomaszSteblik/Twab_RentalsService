using MongoDB.Driver;

namespace UsersService.Infrastructure.Repositories;

public abstract class MongoRepositoryBase<T>
{
    private const string DatabaseName = "UsersServiceDb";
    protected readonly IMongoClient _mongoClient;

    protected MongoRepositoryBase(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    protected IMongoCollection<T> GetCollection()
    {
        var database = _mongoClient.GetDatabase(DatabaseName);
        var collection = database.GetCollection<T>(nameof(T));
        return collection;
    }
}