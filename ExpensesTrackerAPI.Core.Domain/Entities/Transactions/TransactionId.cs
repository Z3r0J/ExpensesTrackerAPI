namespace ExpensesTrackerAPI.Core.Domain.Entities.Transactions;

public readonly record struct TransactionId(Guid Id)
{
    public static TransactionId Empty => new(Guid.Empty);
    public static TransactionId New => new(Guid.NewGuid());

    public override string ToString() => Id.ToString();
};
