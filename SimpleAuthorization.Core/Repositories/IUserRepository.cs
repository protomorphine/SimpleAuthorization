using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Создание нового пользователя
    /// </summary>
    /// <param name="entity">сущность - пользователь</param>
    /// <returns><see cref="UserDto"/></returns>
    Task<long> CreateAsync(User entity);

    /// <summary>
    /// Получение пользователя по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    Task<User?> GetByIdAsync(long id);

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

    /// <summary>
    /// Метод удаления пользователя по идентификтаору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    Task DeleteUserAsync(long id);

    /// <summary>
    /// Метод обновления пользователя
    /// </summary>
    /// <param name="user">сущность - пользователь</param>
    Task UpdateUserAsync(User user);
}
