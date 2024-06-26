﻿using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Accounts.ValueObject;

public record AccountBalanceInfo(Money TotalAmount)
{
    public AccountBalanceInfo() : this(Money.Zero())
    {
        
    }

    public Money CurrentAmount { get; private set; } = Money.Zero();

    public static AccountBalanceInfo None = new(Money.Zero());

    bool IEquatable<AccountBalanceInfo>.Equals(AccountBalanceInfo? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return TotalAmount == other.TotalAmount;
    }

    public bool AmountReached()
    {
        return CurrentAmount.Amount >= TotalAmount.Amount;
    }

    public void UpdateCurrentAmount(TransactionType transactionType, Money amount)
    {
        if (amount.Currency != TotalAmount.Currency)
        {
            amount = amount.ConvertTo(TotalAmount.Currency, 1);
        }

        if (transactionType == TransactionType.Expense)
        {
            CurrentAmount -= amount;
        }
        else
        {
            CurrentAmount += amount;
        }
    }
}
