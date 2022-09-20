using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.Core.Services;

/// <summary>
/// Сервис для работы с пользователями
/// </summary>
public class UsersService : IUsersService
{
    /// <summary>
    /// Репозиторий для работы с пользователями
    /// </summary>
    private readonly IUserRepository _usersRepository;
    
    /// <summary>
    /// Создает новый экземпляр <see cref="UsersService"/>
    /// </summary>
    /// <param name="userRepository">Репозитоий для работы с пользователями</param>
    public UsersService(IUserRepository userRepository)
    {
        _usersRepository = userRepository;
    }

    /// <summary>
    /// Создает нового пользователя
    /// </summary>
    /// <param name="dto"><see cref="CreateUserDto"/></param>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto> CreateNewAsync(CreateUserDto dto)
    {
        var created = await _usersRepository.CreateAsync(new User()
        {
            Fio = dto.Fio,
            Login = dto.Login,
            PasswordHash = dto.Password
        });

        return created;
    }

    /// <summary>
    /// Получение пользоваля по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto> GetByIdAsync(long id)
    {
        return await _usersRepository.GetByIdAsync(id);
    }
}
