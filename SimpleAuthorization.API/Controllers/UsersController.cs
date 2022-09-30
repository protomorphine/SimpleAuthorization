﻿using Microsoft.AspNetCore.Mvc;
using SimpleAuthorization.API.Attributes;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.API.Controllers;

/// <summary>
/// Контроллер пользователей
/// </summary>
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    private readonly IUsersService _usersService;

    /// <summary>
    /// Создает новый экземпляр <see cref="UsersController"/>
    /// </summary>
    /// <param name="usersService">Сервис для работы с пользователями <see cref="IUsersService"/></param>
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    /// <summary>
    /// Метод создания нового пользователя
    /// </summary>
    /// <param name="request"><see cref="CreateUserDto"/></param>
    /// <returns><see cref="UserDto"/></returns>
    //[AuthReqired]
    [HttpPost("create")]
    public async Task<UserDto> CreateNew([FromBody] CreateAndUpdateUserDto request)
    {
        return await _usersService.CreateNewAsync(request);
    }

    /// <summary>
    /// Получение информации о пользователе по id
    /// </summary>
    /// <param name="id">id пользователя</param>
    /// <returns><see cref="UserDto"/></returns>
    //[AuthReqired]
    [HttpGet("{id}")]
    public async Task<UserDto> GetById(long id)
    {
        return await _usersService.GetByIdAsync(id);
    }

    /// <summary>
    /// Получение списка всех пользователей
    /// </summary>
    /// <returns><see cref="List{UserDto}"/></returns>
    [AuthReqired]
    [HttpGet("all")]
    public async Task<List<UserDto>> GetAllUsers()
    {
        return await _usersService.GetAllAsync();
    }

    /// <summary>
    /// Метод удаления пользователя по идентификатору
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(long id)
    {
        await _usersService.DeleteUserAsync(id);
        return Ok();
    }

    /// <summary>
    /// Метод обновления пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <param name="dto">дто изменения и создания пользователя</param>
    /// <returns>дто измененного пользователя</returns>
    [HttpPut("{id:long}")]
    public async Task<UserDto> UpdateById(long id, [FromBody] CreateAndUpdateUserDto dto)
    {
        return await _usersService.UpdateUserAsync(id, dto);
    }

    /// <summary>
    /// Метод блокировки пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/> заблокированного пользователя</returns>
    [HttpPut("{id:long}/block")]
    public async Task<UserDto> BlockUser(long id)
    {
        return await _usersService.BlockUserAsync(id);
    }
}
