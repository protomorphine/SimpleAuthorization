using Microsoft.Extensions.Caching.Memory;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Extensions;
using SimpleAuthorization.Core.Managers.Interfaces;
using SimpleAuthorization.Core.Repositories;

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

    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Созздает новый экземпляр <see cref="AuthManager"/>
    /// </summary>
    /// <param name="cache"></param>
    public AuthManager(IMemoryCache cache, IUserRepository userRepository)
    {
        _cache = cache;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Получение информации о текущем пользователе
    /// </summary>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto> GetCurrentUserInfoAsync(string token)
    {
        var userId = (long)_cache.Get(token);

        var user = await _userRepository.GetByIdAsync(userId);

        return user;
    }

    /// <summary>
    /// Авторизация пользователя по логину и паролю
    /// </summary>
    /// <param name="username">логин</param>
    /// <param name="password">пароль</param>
    public async Task<string> SignInAsync(string username, string password)
    {
        var hashedPassword = password.ComputeSHA256Hash();
        var user = await _userRepository.GetByLoginAsync(username);

        if (hashedPassword != user.PasswordHash) throw new UnauthorizedAccessException("Неверный пароль");
        
        var userToken = Guid.NewGuid().ToString();
        _cache.Set(userToken, user.Id, DateTime.Now.AddHours(1));

        return userToken;

    }

    /// <summary>
    /// Деавторизация пользователя
    /// </summary>
    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }
}
