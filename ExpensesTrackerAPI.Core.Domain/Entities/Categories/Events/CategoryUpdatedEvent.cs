using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Categories.Events;

public class CategoryUpdatedEvent : DomainEvent
{
    public CategoryUpdatedEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; } = Guid.Empty;
}
