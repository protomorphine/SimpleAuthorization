namespace SimpleAuthorization.Core.Dtos;

/// <summary>
/// Дто организации
/// </summary>
public class OrganizationDto
{
    /// <summary>
    /// Идентификатор организации
    /// </summary>
    public long OrganizationId { get; set; }
    
    /// <summary>
    /// Имя организации
    /// </summary>
    public string OrganizationName { get; set; }
    
    
}