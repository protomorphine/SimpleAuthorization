namespace SimpleAuthorization.API.Models;

/// <summary>
/// Описание настроек подключения к базе данных
/// </summary>
public class DbOptions
{
    /// <summary>
    /// Строка подключения к базе данных
    /// </summary>
    public string? ConnectionString { get; set; }
}
