using Domain.Contracts.Common;

namespace Domain.Common;

public abstract class AggregateRoot : Entity
{
    protected readonly Queue<DomainEvent> _domainEvents = new();

    protected void Enqueue<TDomainEvent>(TDomainEvent @event) where TDomainEvent : DomainEvent
    {
        _domainEvents.Enqueue(@event);
    }

    public IEnumerable<DomainEvent> GetQueuedEvents() => _domainEvents.ToArray();
}
