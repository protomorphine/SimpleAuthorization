using SimpleAuthorization.Core.Exceptions;

namespace SimpleAuthorization.Core.Extensions;

internal static class ObjectNotFoundExtensions
{
    public static void ThrowIfNotFound<T>(this T obj, string message)
    {
        if (obj == null)
            throw new ObjectNotFoundException(message);
    }
}

