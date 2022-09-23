﻿using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
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
        var user = await _usersRepository.GetByLoginAsync(dto.Login);
        if (user != null)
            throw new UserAlreadyExistException($"Пользователь с логином {dto.Login} уже есть в системе.");

        var created = await _usersRepository.CreateAsync(new User()
        {
            Fio = dto.Fio,
            Login = dto.Login,
            PasswordHash = dto.Password!.ComputeSha256Hash()
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
        var user = await _usersRepository.GetByIdAsync(id);
        user.ThrowIfNotFound($"Пользователь с id = {id} не найден.");

        return user!;
    }

    /// <summary>
    /// Получение списка всех пользователей
    /// </summary>
    /// <returns><see cref="List{UserDto}"/></returns>
    public async Task<List<UserDto>> GetAllAsync()
    {
        return await _usersRepository.GetUsersAsync();
    }
}
