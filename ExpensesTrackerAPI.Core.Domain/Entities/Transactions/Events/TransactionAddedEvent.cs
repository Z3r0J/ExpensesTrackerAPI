using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Events;

internal class TransactionAddedEvent : DomainEvent
{
    public Guid TransactionId { get; private set; } = Guid.Empty;

    public TransactionAddedEvent(Guid Id)
    {
        TransactionId = Id;
    }
}
