namespace SimpleAuthorization.Core.Exceptions;

/// <summary>
/// Эксепшн, выбрасываемый когда пользователь не авторизован
/// </summary>
public class UnauthorizedException : Exception
{
    /// <summary>
    /// Создает новый экземпляр <see cref="UnauthorizedException"/>
    /// </summary>
    /// <param name="message">сообщение об ошибке</param>
    public UnauthorizedException(string message) : base(message)
    {
    }
}