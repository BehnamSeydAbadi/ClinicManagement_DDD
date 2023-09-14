using MediatR;

namespace Domain.Contracts.Common;

public abstract class DomainEvent : INotification
{
    public int AggregateId { get; init; }
}
