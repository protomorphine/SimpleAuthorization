namespace SimpleAuthorization.Core.Exceptions;

/// <summary>
/// Эксепшн вызываемый когда объект не найден
/// </summary>
public class ObjectNotFoundException : Exception
{
    /// <summary>
    /// Создает новый экземпляр <see cref="ObjectNotFoundException"/>
    /// </summary>
    /// <param name="message">сообщение об ошибке</param>
    public ObjectNotFoundException(string message) : base(message)
    {
    }
}
