using Microsoft.AspNetCore.Mvc;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Managers.Interfaces;

namespace SimpleAuthorization.API.Controllers;

/// <summary>
/// Контроллер управления досутпом
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Менеджер авторизации
    /// </summary>
    private readonly IAuthManager _authManager;

    /// <summary>
    /// Создает новый экземпляр <see cref="AuthController"/>
    /// </summary>
    /// <param name="authManager">Менеджер авторизации</param>
    public AuthController(IAuthManager authManager)
    {
        _authManager = authManager;
    }

    /// <summary>
    /// Авторизует пользователя
    /// </summary>
    /// <param name="request">Дто авторизации</param>
    /// <returns></returns>
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync([FromBody] SignInDto request)
    {
        var token = await _authManager.SignInAsync(request);
        Response.Cookies.Append("auth", token, new CookieOptions() { HttpOnly = true, Expires = DateTime.Now.AddHours(1) });
        return Ok();
    }

    /// <summary>
    /// Разлогинивает пользователя
    /// </summary>
    [HttpPost("sing-out")]
    public async void SignOutAsync()
    {
        var token = Request.Cookies.FirstOrDefault(c => c.Key == "auth").Value;
        await _authManager.SignOutAsync(token);
    }

    /// <summary>
    /// Получение информации о текущем пользователе
    /// </summary>
    /// <returns><see cref="UserDto"/></returns>
    [HttpGet("info")]
    public async Task<UserDto> GetCurrentUserInfo()
    {
        var token = Request.Cookies["auth"];
        return await _authManager.GetUserByTokenAsync(token);
    }
}