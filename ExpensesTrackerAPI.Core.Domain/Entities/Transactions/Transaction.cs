using ExpensesTrackerAPI.Core.Domain.Entities.Accounts;
using ExpensesTrackerAPI.Core.Domain.Entities.Categories;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;
using ExpensesTrackerAPI.Core.Domain.Entities.Users;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Transactions;

public class Transaction : AggregateRoot<TransactionId>
{
    private Transaction() { }

    private Transaction(
        TransactionId id,
        string description,
        Money amount,
        PaymentMethod paymentMethod,
        TransactionType transactionType,
        AccountId accountId,
        CategoryId categoryId,
        DateTime transactionDate,
        UserId userId
    )
        : base(id)
    {
        Description = description;
        Amount = amount;
        PaymentMethod = paymentMethod;
        TransactionType = transactionType;
        AccountId = accountId;
        CategoryId = categoryId;
        TransactionDate = transactionDate;
        UserId = userId;
    }

    public string Description { get; private set; } = string.Empty;
    public Money Amount { get; private set; } = Money.Zero();
    public PaymentMethod PaymentMethod { get; private set; } = PaymentMethod.Cash;
    public TransactionType TransactionType { get; private set; } = TransactionType.Expense;
    public AccountId AccountId { get; private set; } = AccountId.Empty;
    public CategoryId CategoryId { get; private set; } = CategoryId.Empty;
    public DateTime TransactionDate { get; private set; } = DateTime.UtcNow;
    public UserId UserId { get; private set; } = UserId.Empty;

    // Navigation Properties
    public Category? Category { get; private set; }
    public Account? Account { get; private set; }

    public static Transaction Create(
        string description,
        Money amount,
        PaymentMethod paymentMethod,
        TransactionType transactionType,
        AccountId accountId,
        CategoryId categoryId,
        DateTime transactionDate,
        UserId userId
    )
    {
        return new(
            TransactionId.New,
            description,
            amount,
            paymentMethod,
            transactionType,
            accountId,
            categoryId,
            transactionDate,
            userId
        );
    }
}
