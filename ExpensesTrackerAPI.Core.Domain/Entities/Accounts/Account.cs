using ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Events;
using ExpensesTrackerAPI.Core.Domain.Entities.Accounts.ValueObject;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Events;
using ExpensesTrackerAPI.Core.Domain.Entities.Users;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Accounts;

public sealed class Account : AggregateRoot<AccountId>
{
    private List<Transaction> _transactions = new();

    private Account(AccountId id, string name, UserId userId, bool isActive, AccountType accountType)
        : base(id)
    {
        Name = name;
        UserId = userId;
        IsActive = isActive;
        AccountType = accountType;
    }

    private Account() { }

    public string Name { get; private set; } = string.Empty;
    public UserId UserId { get; private set; } = UserId.Empty;
    public bool IsActive { get; private set; } = true;
    public AccountType AccountType { get; private set; } = AccountType.None;
    public AccountBalanceInfo Balance { get; private set; } = AccountBalanceInfo.None;

    public bool IsFull => Balance.AmountReached();

    public static Account Create(
        string name,
        UserId userId,
        bool isActive,
        AccountType accountType
    )
    {
        var id = AccountId.New;

        Raise(new AccountCreatedEvent(id));

        return new(id, name, userId, isActive, accountType);
    }

    public void Update(string? name, bool? isActive, AccountType? accountType)
    {
        Name = name ?? Name;
        IsActive = isActive ?? IsActive;
        AccountType = accountType ?? AccountType;

        Raise(new AccountUpdatedEvent(Id.Value));
    }

    public void SetAccountBalance(AccountBalanceInfo accountInformation)
    {
        Balance = accountInformation;
    }

    public IEnumerable<Transaction> Transactions
    {
        get => _transactions;
        private set => _transactions = (List<Transaction>)value;
    }

    public void AddTransaction(Transaction transaction)
    {
        if (Balance.AmountReached())
        {
            throw new InvalidOperationException("The amount is reached");
        }

        _transactions.Add(transaction);

        UpdateAccountAmount(transaction);

        Raise(new TransactionAddedEvent(transaction.Id));
    }

    public void InactivateAccount()
    {
        IsActive = false;

        Raise(new AccountInactivatedEvent(Id.Value));
    }

    private void UpdateAccountAmount(Transaction transaction)
    {
        if (!Balance.AmountReached())
            Balance.UpdateCurrentAmount(transaction.TransactionType, transaction.Amount);

        Raise(new AccountBalanceUpdatedEvent(Id.Value));
    }
}
