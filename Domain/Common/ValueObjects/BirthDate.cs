namespace Domain.Common.ValueObjects;

public record BirthDate
{
    public DateOnly Value { get; }

    public BirthDate(DateOnly value) => Value = value;
}
