namespace ExpensesTrackerAPI.Core.Domain.Primitives;

public abstract class AggregateRoot : Entity
{
    private static readonly List<DomainEvent> _domainEvents = new();

    protected AggregateRoot(Guid id)
        : base(id) { }

    protected AggregateRoot()
        : base() { }

    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents;

    public static void Raise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
