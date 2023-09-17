using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Budgets.ValueObject;

public record SavingGoal(string GoalName, Money TargetAmount)
{
    public Money ReachedAmount { get; private set; } = Money.Zero();

    public static SavingGoal None = new(string.Empty, Money.Zero());

    bool IEquatable<SavingGoal>.Equals(SavingGoal? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return GoalName == other.GoalName && TargetAmount == other.TargetAmount;
    }

    public bool GoalIsReached()
    {
        return ReachedAmount.Amount >= TargetAmount.Amount;
    }

    public void UpdateReachAmount(TransactionType transactionType, Money Amount)
    {
        if (Amount.Currency != TargetAmount.Currency)
        {
            Amount = Amount.ConvertTo(TargetAmount.Currency, 1);
        }

        if (transactionType == TransactionType.Expense)
        {
            ReachedAmount -= Amount;
        }
        else
        {
            ReachedAmount += Amount;
        }
    }
}
