namespace Domain.Common.ValueObjects;

public record NationalCode
{
    public string Value { get; }

    public NationalCode(string value) => Value = value;
}
