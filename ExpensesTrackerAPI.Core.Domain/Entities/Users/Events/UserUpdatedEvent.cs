using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Users.Events;

public class UserUpdatedEvent : DomainEvent
{
    public UserUpdatedEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
