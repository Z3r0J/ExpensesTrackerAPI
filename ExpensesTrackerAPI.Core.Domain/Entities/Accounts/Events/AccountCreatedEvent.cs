using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Events;

public class AccountCreatedEvent : DomainEvent
{
    public Guid Id { get; private set; } = Guid.Empty;

    public AccountCreatedEvent(Guid id)
    {
        Id = id;
    }
}
