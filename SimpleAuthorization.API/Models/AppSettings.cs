namespace SimpleAuthorization.API.Models;

/// <summary>
/// Описание настроек приложения
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Описание настроек подключения к база данных
    /// </summary>
    public DbOptions? DbOptions { get; set; } 
}
