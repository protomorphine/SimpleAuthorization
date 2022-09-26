using SimpleAuthorization.Core.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAuthorization.Core.Entities;

/// <summary>
/// Класс описаня сущности пользователь
/// </summary>
[Table("users")]
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Column("id")]
    public long Id { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    [Column("login")]
    public string? Login { get; set; }

    /// <summary>
    /// Вычисленный хэш пароля пользователя
    /// </summary>
    [Column("password_hash")]
    public string? PasswordHash { get; set; }

    /// <summary>
    /// ФИО пользователя
    /// </summary>
    [Column("fio")]
    public string? Fio { get; set; }
    
    [Column("org_id")]
    public long? OrganizationId { get; set; }
    
    public Organization? Organization { get; set; }

    /// <summary>
    /// Мапинг сущности на дто
    /// </summary>
    /// <returns><see cref="UserDto"/></returns>
    public UserDto ToUserDto()
    {
        return new UserDto
        {
            Fio = Fio!,
            Login = Login!,
            Id = Id
        };
    }
}
