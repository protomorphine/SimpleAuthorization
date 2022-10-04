using SimpleAuthorization.Core.Enums;

namespace SimpleAuthorization.Core.Dtos;

/// <summary>
/// Дто пользователя
/// </summary>
public class UserDto
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string? Login { get; set; }

    /// <summary>
    /// ФИО пользователя
    /// </summary>
    public string? Fio { get; set; }

    /// <summary>
    /// Организация пользователя
    /// </summary>
    public OrganizationDto? Organization { get; set; }
    
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public UserRoles Role { get; set; }
}
