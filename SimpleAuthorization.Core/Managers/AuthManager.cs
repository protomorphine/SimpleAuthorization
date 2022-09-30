using SimpleAuthorization.Core.Dtos;
using Microsoft.Extensions.Caching.Memory;
using SimpleAuthorization.Core.Exceptions;
using SimpleAuthorization.Core.Extensions;
using SimpleAuthorization.Core.Repositories;
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
    /// Репозиторий для работы с пользователями
    /// </summary>
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Созздает новый экземпляр <see cref="AuthManager"/>
    /// </summary>
    /// <param name="cache">Кэш для хранения токенов</param>
    /// <param name="userRepository">Репозиторий для работы с пользователями</param>
    public AuthManager(IMemoryCache cache, IUserRepository userRepository)
    {
        _cache = cache;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Получение информации о текущем пользователе
    /// </summary>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto> GetUserByTokenAsync(string token)
    {
        _cache.TryGetValue(token, out long userId);
        var user = await _userRepository.GetAsync(userId);

        if (user == null)
            throw new UnauthorizedException("Unauthorized");

        return user!.ToUserDto();
    }

    /// <summary>
    /// Авторизация пользователя по логину и паролю
    /// </summary>
    /// <param name="dto"><see cref="SignInDto"/></param>
    public async Task<string> SignInAsync(SignInDto dto)
    {
        var hashedPassword = dto.Password!.ComputeSha256Hash();
        var user = await _userRepository.GetByLoginAsync(dto.Login!);

        user.ThrowIfNotFound($"Пользователь {dto.Login!} не найден.");

        if (hashedPassword != user.PasswordHash) throw new UnauthorizedAccessException("Неверный пароль");

        var userToken = Guid.NewGuid().ToString();
        _cache.Set(userToken, user.Id, DateTimeOffset.Now.AddHours(1));

        return userToken;

    }

    /// <summary>
    /// Деавторизация пользователя
    /// </summary>
    public async Task SignOutAsync(string token)
    {
        await Task.Run(() => _cache.Remove(token));
    }
}
