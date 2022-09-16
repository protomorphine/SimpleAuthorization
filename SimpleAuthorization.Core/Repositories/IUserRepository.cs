using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User entity);

    Task<User> GetByIdAsync(long id);

    Task<List<User>> GetUsersAsync();
}
