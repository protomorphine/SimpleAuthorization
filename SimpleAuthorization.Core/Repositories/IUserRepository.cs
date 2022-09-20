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
    Task<UserDto> CreateAsync(User entity);

    /// <summary>
    /// Получение пользователя по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    Task<UserDto> GetByIdAsync(long id);

    Task<User> GetByLoginAsync(string login);

    /// <summary>
    /// Получение списка всех пользователей
    /// </summary>
    /// <returns>список <see cref="User"/></returns>
    Task<List<User>> GetUsersAsync();
}
