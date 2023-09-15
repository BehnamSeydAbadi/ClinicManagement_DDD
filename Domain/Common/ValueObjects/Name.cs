using Domain.Common.Exceptions;

namespace Domain.Common.ValueObjects;

public record Name
{
    public Name(string first, string last)
    {
        if (string.IsNullOrWhiteSpace(first))
            ArgumentIsNullException.Throw(nameof(first));

        if (string.IsNullOrWhiteSpace(last))
            ArgumentIsNullException.Throw(nameof(last));

        First = first;
        Last = last;
    }

    public string First { get; }
    public string Last { get; }
}

