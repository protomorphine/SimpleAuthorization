namespace SimpleAuthorization.Core.Dtos;

/// <summary>
/// Дто организации
/// </summary>
public class OrganizationDto
{
    /// <summary>
    /// Идентификатор организации
    /// </summary>
    public long OrgId { get; set; }

    /// <summary>
    /// Имя организации
    /// </summary>
    public string OrgName { get; set; } = String.Empty;
}