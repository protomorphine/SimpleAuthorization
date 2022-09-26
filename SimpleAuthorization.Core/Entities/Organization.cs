using System.ComponentModel.DataAnnotations.Schema;

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
    public string Name { get; set; }

    /// <summary>
    /// Связь сущностей организаця - пользователь
    /// </summary>
    public List<User> Users { get; set; }
}