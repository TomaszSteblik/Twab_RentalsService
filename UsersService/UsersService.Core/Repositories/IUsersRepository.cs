using UsersService.Core.Entities;

namespace UsersService.Core.Repositories;

public interface IUsersRepository
{
    Task<User> GetUserById(Guid id);
    Task<bool> AddUser(User user);
}