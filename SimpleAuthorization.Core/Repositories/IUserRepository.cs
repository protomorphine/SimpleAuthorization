using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями
/// </summary>
public interface IUserRepository : IBaseRepository<User, long>
{
    /// <summary>
    /// Получение пользователя по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    Task<User?> GetAsync(long id);

    /// <summary>
    /// Получение пользователя по логину
    /// </summary>
    /// <param name="login">логин пользователя</param>
    /// <returns><see cref="User"/></returns>
    Task<User?> GetByLoginAsync(string login);

    /// <summary>
    /// Получение списка всех пользователей
    /// </summary>
    /// <returns>список <see cref="UserDto"/></returns>
    Task<List<UserDto>> GetUsersAsync();
}
