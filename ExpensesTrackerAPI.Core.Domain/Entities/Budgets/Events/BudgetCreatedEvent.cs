using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Budgets.Events;

public class BudgetCreatedEvent : DomainEvent
{
    public Guid Id { get; private set; } = Guid.Empty;

    public BudgetCreatedEvent(Guid id)
    {
        Id = id;
    }
}
