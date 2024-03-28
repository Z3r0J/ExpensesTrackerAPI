using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Events;

internal class TransactionAddedEvent : DomainEvent
{
    public TransactionId TransactionId { get; private set; }

    public TransactionAddedEvent(TransactionId Id)
    {
        TransactionId = Id;
    }
}
