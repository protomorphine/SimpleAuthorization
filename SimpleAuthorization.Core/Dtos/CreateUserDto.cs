namespace SimpleAuthorization.Core.Dtos;

/// <summary>
/// Дто создания нового пользователя
/// </summary>
public class CreateUserDto
{
    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string? Login { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Фио пользоваетля
    /// </summary>
    public string? Fio { get; set; }

    /// <summary>
    /// Идентификатор организации пользователя
    /// </summary>
    public long? OrganizationId { get; set; }
}
