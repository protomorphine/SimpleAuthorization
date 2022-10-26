using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Enums;

namespace SimpleAuthorization.Core.Entities;

/// <summary>
/// Класс описаня сущности пользователь
/// </summary>
//[Table("users")]
public class User : IEntity<long>
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
    /// Вычисленный хэш пароля пользователя
    /// </summary>
    public string? PasswordHash { get; set; }

    /// <summary>
    /// ФИО пользователя
    /// </summary>
    public string? Fio { get; set; }

    /// <summary>
    /// ID организации пользователя
    /// </summary>
    public long? OrganizationId { get; set; }

    /// <summary>
    /// Статус учетной записи
    /// </summary>
    public UserStatus UserStatus { get; set; }

    /// <summary>
    /// Роль пользователя
    /// </summary>
    public UserRoles UserRole { get; set; }
    
    /// <summary>
    /// Рейтинг пользователя
    /// </summary>
    public float Rating { get; set; }
    
    /// <summary>
    /// Зарплата пользователя
    /// </summary>
    public decimal Salary { get; set; }
    
    /// <summary>
    /// Должность пользователя
    /// </summary>
    public UserPosition Position { get; set; }

    /// <summary>
    /// Связь сущностей пользователь - организация
    /// </summary>
    public virtual Organization? Organization { get; set; }

    /// <summary>
    /// Связь сущностей пользователь организация
    /// </summary>
    public virtual Organization HeadOf { get; set; }

    /// <summary>
    /// Мапинг сущности на дто
    /// </summary>
    /// <returns><see cref="UserDto"/></returns>
    public UserDto ToUserDto()
    {
        return new()
        {
            Fio = Fio!,
            Login = Login!,
            Id = Id,
            Role = UserRole,
            Organization = Organization?.ToOrganizationDto(),
        };
    }
}
