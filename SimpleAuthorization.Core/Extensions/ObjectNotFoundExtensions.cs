using SimpleAuthorization.Core.Exceptions;

namespace SimpleAuthorization.Core.Extensions;

/// <summary>
/// Методы расширения для проверки объекта на null
/// </summary>
internal static class ObjectNotFoundExtensions
{
    /// <summary>
    /// Выбрасывает исключение если объект равен null
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public static void ThrowIfNotFound<T>(this T obj, string message)
    {
        if (obj == null)
            throw new ObjectNotFoundException(message);
    }
}

