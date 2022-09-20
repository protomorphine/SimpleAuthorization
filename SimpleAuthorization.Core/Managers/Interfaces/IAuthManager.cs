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
    /// <param name="username">логин</param>
    /// <param name="password">пароль</param>
    Task<string> SignInAsync(string username, string password);

    /// <summary>
    /// Деавторизация пользователя
    /// </summary>
    Task SignOutAsync();

    /// <summary>
    /// Получение информации о текущем пользователе
    /// </summary>
    /// <returns><see cref="UserDto"/></returns>
    Task<UserDto> GetCurrentUserInfoAsync(string token);
}
