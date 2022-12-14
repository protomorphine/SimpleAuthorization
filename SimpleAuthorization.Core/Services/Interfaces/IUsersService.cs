using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Enums;

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
    /// <param name="dto">параметры фильтрации списка пользователей</param>
    /// <returns><see cref="List{UserDto}"/></returns>
    Task<List<UserDto>> GetAllAsync(GetUsersQueryParamsDto dto);

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

    /// <summary>
    /// Метод разблокировки пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/> разблокированного пользователя</returns>
    Task<UserDto> UnblockUserAsync(long id);

    /// <summary>
    /// Метод получения роли пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns>роль пользователя</returns>
    Task<UserRoles> GetUserRole(long id);
}
