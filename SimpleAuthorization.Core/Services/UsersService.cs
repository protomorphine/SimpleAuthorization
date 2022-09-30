using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Enums;
using SimpleAuthorization.Core.Exceptions;
using SimpleAuthorization.Core.Extensions;
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

    private readonly IOrganizationRepository _organizationRepository;

    /// <summary>
    /// Создает новый экземпляр <see cref="UsersService"/>
    /// </summary>
    /// <param name="userRepository">Репозитоий для работы с пользователями</param>
    /// <param name="organizationRepository">Репозиторий для работы с организациями</param>
    public UsersService(IUserRepository userRepository, IOrganizationRepository organizationRepository)
    {
        _usersRepository = userRepository;
        _organizationRepository = organizationRepository;
    }

    /// <summary>
    /// Создает нового пользователя
    /// </summary>
    /// <param name="dto"><see cref="CreateUserDto"/></param>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto> CreateNewAsync(CreateUserDto dto)
    {
        if (dto == null)
            throw new InvalidOperationException("Данные создания пользователя отсутствуют.");
        
        var user = await _usersRepository.GetByLoginAsync(dto.Login!);
        if (user != null)
            throw new UserAlreadyExistException($"Пользователь с логином {dto.Login} уже есть в системе.");

        var createdId = await _usersRepository.CreateAsync(new User()
        {
            Fio = dto.Fio,
            Login = dto.Login,
            PasswordHash = dto.Password!.ComputeSha256Hash(),
            OrganizationId = dto.OrganizationId,
            UserStatus = UserStatus.Blocked
        });

        var created = await _usersRepository.GetAsync(createdId);

        return created!.ToUserDto();
    }

    /// <summary>
    /// Получение пользоваля по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto> GetByIdAsync(long id)
    {
        var user = await _usersRepository.GetAsync(id);
        user.ThrowIfNotFound($"Пользователь с id = {id} не найден.");

        return user!.ToUserDto();
    }

    /// <summary>
    /// Получение списка всех пользователей
    /// </summary>
    /// <returns><see cref="List{UserDto}"/></returns>
    public async Task<List<UserDto>> GetAllAsync()
    {
        return await _usersRepository.GetUsersAsync();
    }

    /// <summary>
    /// Метод удаления пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    public async Task DeleteUserAsync(long id)
    {
        var user = await _usersRepository.GetAsync(id);
        user.ThrowIfNotFound($"Пользователь с id = {id} не найден.");
        await _usersRepository.DeleteAsync(user!);
    }

    /// <summary>
    /// Метод обновления пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <param name="dto">дто обновления пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    public async Task<UserDto> UpdateUserAsync(long id, CreateUserDto dto)
    {
        var user = await _usersRepository.GetAsync(id);

        user.ThrowIfNotFound($"Пользователь с id = {id} не найден.");

        user!.Fio = dto.Fio;
        user.Login = dto.Login;
        user.PasswordHash = dto.Password!.ComputeSha256Hash();
        user.OrganizationId = dto.OrganizationId;
        user.Organization = await _organizationRepository.GetAsync(user.OrganizationId!.Value);

        await _usersRepository.UpdateAsync(user);

        return user.ToUserDto();

    }
}
