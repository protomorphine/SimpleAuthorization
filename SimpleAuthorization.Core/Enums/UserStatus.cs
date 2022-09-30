namespace SimpleAuthorization.Core.Enums;

/// <summary>
/// Перечисление статусов пользователя
/// </summary>
public enum UserStatus
{
    /// <summary>
    /// Учетная запись активна
    /// </summary>
    Active = 0,
    
    /// <summary>
    /// Учетная запись заблокирована
    /// </summary>
    Blocked = 1
}