using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Users.Events;

public class UserUpdatedEvent(UserId id) : DomainEvent
{
    public UserId Id { get; private set; } = id;
}
