namespace ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;

public record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money first, Money second)
    {
        if (first.Currency != second.Currency) throw new InvalidOperationException("Cannot sum different currencies");

        return new Money(first.Amount + second.Amount, first.Currency);
    }

    public static Money operator -(Money first, Money second)
    {
        if (first.Currency != second.Currency)
            throw new InvalidOperationException("Cannot subtract different currencies");

        return new Money(first.Amount - second.Amount, first.Currency);
    }

    public static Money Zero()
    {
        return new Money(0, Currency.None);
    }

    public static Money Zero(Currency currency)
    {
        return new Money(0, currency);
    }

    public bool IsZero()
    {
        return this == Zero(Currency);
    }

    public Money ConvertTo(Currency targetCurrency, decimal exchangeRate)
    {
        if (Currency == targetCurrency) return this;

        return new Money(Amount * exchangeRate, targetCurrency);
    }
}