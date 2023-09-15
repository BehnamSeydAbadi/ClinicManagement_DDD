using Domain.Common.Exceptions;

namespace Domain.Common.ValueObjects;

public record NationalCode
{
    public string Value { get; }

    public NationalCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            ArgumentIsNullException.Throw("national code");

        Value = value;
    }
}
