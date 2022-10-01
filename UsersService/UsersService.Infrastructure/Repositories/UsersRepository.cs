using AutoMapper;
using MongoDB.Driver;
using UsersService.Core.Entities;
using UsersService.Core.Repositories;

namespace UsersService.Infrastructure.Repositories;

public class UsersRepository : MongoRepositoryBase<DAOs.User>, IUsersRepository
{
    private readonly IMapper _mapper;
    
    public UsersRepository(IMapper mapper, IMongoClient mongoClient) : base(mongoClient)
    {
        _mapper = mapper;
    }
    
    public async Task<User> GetUserById(Guid id)
    {
        var usersCollection = GetCollection();
        var userCursor = await usersCollection.FindAsync(u => u.Id == id.ToString());
        var user = await userCursor.FirstOrDefaultAsync();
        return _mapper.Map<User>(user);
    }
    
    public async Task<bool> AddUser(User user)
    {
        var usersCollection = GetCollection();
        var userDao = _mapper.Map<DAOs.User>(user);
        await usersCollection.InsertOneAsync(userDao);
        return true;
    }
}