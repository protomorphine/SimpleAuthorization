namespace SimpleAuthorization.Core.Exceptions;

/// <summary>
/// Эксепшн вызываемый когда пользователь уже создан в системе
/// </summary>
public class UserAlreadyExistException : Exception
{
    /// <summary>
    /// Создает новый экземпляр <see cref="UserAlreadyExistException"/>
    /// </summary>
    /// <param name="message">сообщение об ошибке</param>
    public UserAlreadyExistException(string message) : base(message)
    {
    }
}

