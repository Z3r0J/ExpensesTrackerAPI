using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Events;

public class AccountInactivatedEvent : DomainEvent
{
    public AccountInactivatedEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; } = Guid.Empty;
}
