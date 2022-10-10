using SimpleAuthorization.Core.Dtos;

namespace SimpleAuthorization.Core.Entities;

/// <summary>
/// Сущность организации
/// </summary>
public class Organization : IEntity<long>
{
    /// <summary>
    /// ID организации
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя организации
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Идентификатор создателя организации
    /// </summary>
    public long HeadOfOrgUserId { get; set; }

    /// <summary>
    /// Связь сущностей организаця - пользователь (many to one)
    /// </summary>
    public virtual List<User>? Users { get; set; }

    /// <summary>
    /// Связь сущностей организация - пользователь (one to one)
    /// </summary>
    public virtual User HeadOfOrgUser { get; set; }

    /// <summary>
    /// Метод мапинга сущности на дто
    /// </summary>
    /// <returns><see cref="OrganizationDto"/></returns>
    public OrganizationDto ToOrganizationDto()
    {
        return new OrganizationDto()
        {
            OrgId = Id,
            OrgName = Name!
        };
    }
}