namespace Domain.Common.ValueObjects;

public record BirthDate
{
    public DateOnly Value { get; set; }
}
