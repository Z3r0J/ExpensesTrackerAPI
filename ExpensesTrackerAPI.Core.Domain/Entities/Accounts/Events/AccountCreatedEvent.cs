using ExpensesTrackerAPI.Core.Domain.Entities.Users;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Events;

public class AccountCreatedEvent : DomainEvent
{
    public AccountId Id { get; private set; }

    public AccountCreatedEvent(AccountId id)
    {
        Id = id;
    }
}
