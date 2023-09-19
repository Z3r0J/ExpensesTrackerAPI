using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Events;

public class AccountBalanceUpdatedEvent : DomainEvent
{
    public AccountBalanceUpdatedEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; } = Guid.Empty;
}
