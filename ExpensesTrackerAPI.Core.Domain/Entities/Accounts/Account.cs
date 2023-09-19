using ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Events;
using ExpensesTrackerAPI.Core.Domain.Entities.Accounts.ValueObject;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Events;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Accounts;

public sealed class Account : AggregateRoot
{
    public List<Transaction> _transactions = new();

    private Account(Guid id, string name, Guid userId, bool isActive, AccountType accountType)
        : base(id)
    {
        Name = name;
        UserId = userId;
        IsActive = isActive;
        AccountType = accountType;
    }

    private Account()
        : base() { }

    public string Name { get; private set; } = string.Empty;
    public Guid UserId { get; private set; } = Guid.Empty;
    public bool IsActive { get; private set; } = true;
    public AccountType AccountType { get; private set; } = AccountType.None;
    public AccountBalanceInfo Balance { get; private set; } = AccountBalanceInfo.None;

    public bool IsFull
    {
        get => Balance.AmountReached();
        private set { }
    }

    public static Account Create(
        Guid id,
        string name,
        Guid userId,
        bool isActive,
        AccountType accountType
    )
    {
        Raise(new AccountCreatedEvent(id));

        return new(id, name, userId, isActive, accountType);
    }

    public void SetAccountBalance(AccountBalanceInfo accountInformation)
    {
        Balance = accountInformation;
    }

    public IEnumerable<Transaction> Transactions
    {
        get => _transactions;
        private set { _transactions = (List<Transaction>)value; }
    }

    public void AddTransaction(Transaction transaction)
    {
        if (Balance.AmountReached())
        {
            throw new InvalidOperationException("The goal is reached");
        }

        _transactions.Add(transaction);

        UpdateAccountAmount(transaction);

        Raise(new TransactionAddedEvent(transaction.Id));
    }

    public void UpdateAccount(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }

    public void InactivateAccount()
    {
        IsActive = false;

        Raise(new AccountInactivatedEvent(Id));
    }

    private void UpdateAccountAmount(Transaction transaction)
    {
        if (!Balance.AmountReached())
            Balance.UpdateCurrentAmount(transaction.TransactionType, transaction.Amount);
    }
}
