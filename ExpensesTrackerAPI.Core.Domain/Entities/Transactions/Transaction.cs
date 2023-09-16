using ExpensesTrackerAPI.Core.Domain.Entities.Categories;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;
using ExpensesTrackerAPI.Core.Domain.Entities.TransactionTypes;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Transactions;

public class Transaction : AggregateRoot
{
    private Transaction(
        Guid id,
        string description,
        Money amount,
        PaymentMethod paymentMethod,
        Guid transactionId,
        Guid categoryId,
        DateTime transactionDate,
        Guid userId
    )
        : base(id)
    {
        Description = description;
        Amount = amount;
        PaymentMethod = paymentMethod;
        TransactionId = transactionId;
        CategoryId = categoryId;
        TransactionDate = transactionDate;
        UserId = userId;
    }

    public string Description { get; private set; }
    public Money Amount { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    public Guid TransactionId { get; private set; }
    public Guid CategoryId { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public Guid UserId { get; private set; }

    // Navigation Properties
    public TransactionType? TransactionType { get; private set; }
    public Category? Category { get; private set; }

    public static Transaction Create(
        Guid id,
        string description,
        Money amount,
        PaymentMethod paymentMethod,
        Guid transactionId,
        Guid categoryId,
        DateTime transactionDate,
        Guid userId
    )
    {
        return new(
            id,
            description,
            amount,
            paymentMethod,
            transactionId,
            categoryId,
            transactionDate,
            userId
        );
    }
}
