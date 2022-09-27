using System.ComponentModel.DataAnnotations.Schema;
using SimpleAuthorization.Core.Dtos;

namespace SimpleAuthorization.Core.Entities;

/// <summary>
/// Сущность организации
/// </summary>
public class Organization
{
    /// <summary>
    /// ID организации
    /// </summary>
    [Column("id")]
    public long Id { get; set; }
    
    /// <summary>
    /// Имя организации
    /// </summary>
    [Column("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Связь сущностей организаця - пользователь
    /// </summary>
    public virtual List<User> Users { get; set; }

    /// <summary>
    /// Метод мапинга сущности на дто
    /// </summary>
    /// <returns><see cref="OrganizationDto"/></returns>
    public OrganizationDto ToOrganizationDto()
    {
        return new OrganizationDto()
        {
            OrganizationId = Id,
            OrganizationName = Name!
        };
    }
}