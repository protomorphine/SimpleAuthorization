using Microsoft.Extensions.Caching.Memory;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Managers.Interfaces;

namespace SimpleAuthorization.Core.Managers;

/// <summary>
/// Менеджер авторизации
/// </summary>
public class AuthManager : IAuthManager
{
    /// <summary>
    /// Кэш приложения для хранения токентов
    /// </summary>
    private readonly IMemoryCache _cache;

    /// <summary>
    /// Созздает новый экземпляр <see cref="AuthManager"/>
    /// </summary>
    /// <param name="cache"></param>
    public AuthManager(IMemoryCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    /// Получение информации о текущем пользователе
    /// </summary>
    /// <returns><see cref="UserDto"/></returns>
    public Task<UserDto> GetCurrentUserInfoAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Авторизация пользователя по логину и паролю
    /// </summary>
    /// <param name="username">логин</param>
    /// <param name="password">пароль</param>
    public Task SignInAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Деавторизация пользователя
    /// </summary>
    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }
}
