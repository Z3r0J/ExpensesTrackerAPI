namespace ExpensesTrackerAPI.Core.Domain.Primitives;

public abstract class AggregateRoot : Entity
{
    private readonly List<DomainEvent> _domainEvents = new();

    protected AggregateRoot(Guid id)
        : base(id) { }

    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents;

    public void Raise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
