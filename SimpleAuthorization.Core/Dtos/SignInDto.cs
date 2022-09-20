namespace SimpleAuthorization.Core.Dtos;

/// <summary>
/// Дто авторизации
/// </summary>
public class SignInDto
{
    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string? Login { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string? Password { get; set; }
}
