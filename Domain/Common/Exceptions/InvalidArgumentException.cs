using Common.Exception;

namespace Domain.Common.Exceptions;

public class InvalidArgumentException : Exception, IException
{
    public static InvalidArgumentException Throw(string argumentName)
    {
        throw new InvalidArgumentException(argumentName);
    }

    private InvalidArgumentException(string argumentName) : base($"{argumentName} is invalid")
    {
    }
}
