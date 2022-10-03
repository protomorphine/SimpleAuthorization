namespace SimpleAuthorization.API.Models;

/// <summary>
/// Модель эндпоинта
/// </summary>
public class EndpointModel
{
    /// <summary>
    /// Имя контроллера
    /// </summary>
    public string Controller { get; set; }

    /// <summary>
    /// Имя метода
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// HTTP метод
    /// </summary>
    public string? Method { get; set; }
}