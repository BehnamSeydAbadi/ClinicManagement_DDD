using Domain.Common.Exceptions;

namespace Domain.Common.ValueObjects;

public record PhoneNumber
{
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            ArgumentIsNullException.Throw("phone number");

        if (value.Any(c => char.IsDigit(c) is false))
            InvalidArgumentException.Throw("phone number");

        Value = value;
    }

    public string Value { get; }
}
