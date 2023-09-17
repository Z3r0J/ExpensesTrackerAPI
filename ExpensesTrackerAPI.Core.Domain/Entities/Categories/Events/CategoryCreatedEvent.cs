using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Categories.Events;

public sealed class CategoryCreatedEvent : DomainEvent
{
    public Guid Id { get; private set; }

    public CategoryCreatedEvent(Guid id)
    {
        Id = id;
    }
}
