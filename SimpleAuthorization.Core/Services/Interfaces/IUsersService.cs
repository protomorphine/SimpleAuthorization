﻿using SimpleAuthorization.Core.Dtos;

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
    Task<UserDto> CreateNewAsync(CreateUserDto dto);

    /// <summary>
    /// Получение пользоваля по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    Task<UserDto> GetByIdAsync(long id);

}
