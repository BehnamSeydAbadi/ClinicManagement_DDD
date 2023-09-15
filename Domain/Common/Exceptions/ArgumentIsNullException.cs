using Common.Exception;

namespace Domain.Common.Exceptions;

public class ArgumentIsNullException : ArgumentNullException, IException
{
    public static ArgumentIsNullException Throw(string argumentName)
    {
        throw new ArgumentIsNullException(argumentName);
    }

    private ArgumentIsNullException(string argumentName) : base(argumentName) { }
}
