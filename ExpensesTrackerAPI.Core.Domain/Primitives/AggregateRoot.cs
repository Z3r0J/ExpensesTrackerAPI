using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTrackerAPI.Core.Domain.Primitives;

public abstract class AggregateRoot<TId> : Entity<TId>
{
    [NotMapped]
    private static readonly List<DomainEvent> _domainEvents = new();

    protected AggregateRoot(TId id)
        : base(id) { }

    protected AggregateRoot()
        : base() { }
    [NotMapped]
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents;

    public static void Raise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
