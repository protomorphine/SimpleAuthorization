namespace SimpleAuthorization.Core.Exceptions;

public class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException(string message) : base(message)
    {
    }
}
