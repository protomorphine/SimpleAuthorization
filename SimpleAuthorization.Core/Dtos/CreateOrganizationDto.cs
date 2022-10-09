namespace SimpleAuthorization.Core.Dtos;

/// <summary>
/// Дто создания организации
/// </summary>
public class CreateOrganizationDto
{
    /// <summary>
    /// Имя организации
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Идентификатор создателя организации
    /// </summary>
    public long CreatorId { get; set; }
}