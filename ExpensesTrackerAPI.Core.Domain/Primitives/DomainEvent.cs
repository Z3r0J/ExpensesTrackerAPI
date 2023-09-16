namespace ExpensesTrackerAPI.Core.Domain.Primitives;

public abstract class DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;

    public Guid EventId { get; init; } = Guid.NewGuid();
}
