namespace ExpensesTrackerAPI.Core.Domain.Entities.Accounts;

public readonly record struct AccountId(Guid Value)
{
    public static AccountId Empty => new(Guid.Empty);
    public static AccountId New => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
};