using Domain.Contracts.Common;

namespace Domain.Common
{
    public abstract class Entity
    {
        protected readonly Queue<DomainEvent> _domainEvents = new Queue<DomainEvent>();

        public int Id { get; init; }

        public IEnumerable<DomainEvent> GetQueuedEvents() => _domainEvents.ToArray();
    }
}
