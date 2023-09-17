using ExpensesTrackerAPI.Core.Domain.Entities.Budgets;
using ExpensesTrackerAPI.Core.Domain.Entities.Categories;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Transactions;

public class Transaction : AggregateRoot
{
    private Transaction()
        : base() { }

    private Transaction(
        Guid id,
        string description,
        Money amount,
        PaymentMethod paymentMethod,
        TransactionType transactionType,
        Guid budgetId,
        Guid categoryId,
        DateTime transactionDate,
        Guid userId
    )
        : base(id)
    {
        Description = description;
        Amount = amount;
        PaymentMethod = paymentMethod;
        TransactionType = transactionType;
        BudgetId = budgetId;
        CategoryId = categoryId;
        TransactionDate = transactionDate;
        UserId = userId;
    }

    public string Description { get; private set; } = string.Empty;
    public Money Amount { get; private set; } = Money.Zero();
    public PaymentMethod PaymentMethod { get; private set; } = PaymentMethod.Cash;
    public TransactionType TransactionType { get; private set; } = TransactionType.Expense;
    public Guid BudgetId { get; private set; } = Guid.Empty;
    public Guid CategoryId { get; private set; } = Guid.Empty;
    public DateTime TransactionDate { get; private set; } = DateTime.UtcNow;
    public Guid UserId { get; private set; } = Guid.Empty;

    // Navigation Properties
    public Category? Category { get; private set; }
    public Budget? Budget { get; private set; }

    public static Transaction Create(
        Guid id,
        string description,
        Money amount,
        PaymentMethod paymentMethod,
        TransactionType transactionType,
        Guid budgetId,
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
            transactionType,
            budgetId,
            categoryId,
            transactionDate,
            userId
        );
    }
}
