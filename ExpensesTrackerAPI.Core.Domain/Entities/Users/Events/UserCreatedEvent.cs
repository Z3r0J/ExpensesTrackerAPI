using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Users.Events
{
    public class UserCreatedEvent : DomainEvent
    {
        public UserCreatedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
