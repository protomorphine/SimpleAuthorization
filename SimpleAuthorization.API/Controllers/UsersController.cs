using Microsoft.AspNetCore.Mvc;
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
    /// Создает нового пользователя
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
    /// <param name="dto">параметры фильтрации списка пользователей</param>
    /// <returns><see cref="List{UserDto}"/></returns>
    [AuthReqired]
    [HttpGet("all")]
    public async Task<List<UserDto>> GetAllUsers([FromQuery] GetUsersQueryParamsDto dto)
    {
        return await _usersService.GetAllAsync(dto);
    }

    /// <summary>
    /// Удаляет пользователя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(long id)
    {
        await _usersService.DeleteUserAsync(id);
        return Ok();
    }

    /// <summary>
    /// Обновление пользователя
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
    /// Блокирует пользоваетляя
    /// </summary>
    /// <param name="id">идентификатор пользователя</param>
    /// <returns><see cref="UserDto"/> заблокированного пользователя</returns>
    [HttpPut("{id:long}/block")]
    public async Task<UserDto> BlockUser(long id)
    {
        return await _usersService.BlockUserAsync(id);
    }

    /// <summary>
    /// Разблокирует пользователя
    /// </summary>
    /// <param name="id"></param>идентификатор пользователя
    /// <returns><see cref="UserDto"/> разблокированного пользователя</returns>
    [HttpPut("{id:long}/unblock")]
    public async Task<UserDto> UnblockUser(long id)
    {
        return await _usersService.UnblockUserAsync(id);
    }
}
