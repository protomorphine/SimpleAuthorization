using System.Security.AccessControl;

namespace SimpleAuthorization.Core.Dtos;

/// <summary>
/// Параметры фильтрации списка пользователей
/// </summary>
public class GetUsersQueryParamsDto
{
    /// <summary>
    /// Строка поиска
    /// </summary>
    public string? SearchString { get; set; }
    
    /// <summary>
    /// Флаг активности
    /// </summary>
    public bool OnlyActive { get; set; }
}