using SimpleAuthorization.Core.Dtos;

namespace SimpleAuthorization.Core.Managers.Interfaces;

/// <summary>
/// Интерфейс мнеджера авторизации
/// </summary>
public interface IAuthManager
{
    /// <summary>
    /// Авторизация пользователя по логину и паролю
    /// </summary>
    /// <param name="dto">дто авторизации</param>
    Task<string> SignInAsync(SignInDto dto);

    /// <summary>
    /// Деавторизация пользователя
    /// </summary>
    Task SignOutAsync(string token);

    /// <summary>
    /// Получение информации о текущем пользователе
    /// </summary>
    /// <returns><see cref="UserDto"/></returns>
    Task<UserDto> GetUserByTokenAsync(string token);
}
