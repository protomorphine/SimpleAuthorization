using SimpleAuthorization.Core.Dtos;

namespace SimpleAuthorization.Core.Services.Interfaces;

/// <summary>
/// Сервис для работы с пользователями
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Создает нового пользователя
    /// </summary>
    /// <param name="dto"><see cref="CreateUserDto"/></param>
    /// <returns><see cref="UserDto"/></returns>
    Task<UserDto> CreateNewAsync(CreateAndUpdateUserDto dto);

    /// <summary>
    /// Получение пользоваля по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    Task<UserDto> GetByIdAsync(long id);

    /// <summary>
    /// Получение списка всех пользователей
    /// </summary>
    /// <returns><see cref="List{UserDto}"/></returns>
    Task<List<UserDto>> GetAllAsync();

    /// <summary>
    /// Метод удаления пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    Task DeleteUserAsync(long id);

    /// <summary>
    /// Метод обновления пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <param name="dto">дто обновления пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    Task<UserDto> UpdateUserAsync(long id, CreateAndUpdateUserDto dto);

    /// <summary>
    /// Метод блокировки пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    Task<UserDto> BlockUserAsync(long id);
}
