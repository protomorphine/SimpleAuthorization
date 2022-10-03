﻿using SimpleAuthorization.Core.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleAuthorization.Core.Enums;

namespace SimpleAuthorization.Core.Entities;

/// <summary>
/// Класс описаня сущности пользователь
/// </summary>
[Table("users")]
public class User : IEntity<long>
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

    /// <summary>
    /// ID организации пользователя
    /// </summary>
    [Column("org_id")]
    public long? OrganizationId { get; set; }

    /// <summary>
    /// Статус учетной записи
    /// </summary>
    [Column("status")]
    public UserStatus UserStatus { get; set; }

    /// <summary>
    /// Роль пользователя
    /// </summary>
    [Column("role")]
    public UserRoles UserRole { get; set; }

    /// <summary>
    /// Связь сущностей пользователь - организация
    /// </summary>
    public virtual Organization? Organization { get; set; }


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
            OrganizationName = Organization?.Name,
            Role = UserRole
        };
    }
}
