namespace Domain.Common.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value) => Value = value;
}
