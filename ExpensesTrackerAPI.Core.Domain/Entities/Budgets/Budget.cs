using ExpensesTrackerAPI.Core.Domain.Entities.Budgets.ValueObject;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Events;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Budgets;

public sealed class Budget : AggregateRoot
{
    public List<Transaction> _transactions = new();

    private Budget(Guid id)
        : base(id) { }

    private Budget()
        : base() { }

    public string Name { get; private set; } = string.Empty;

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public SavingGoal SavingGoal { get; private set; } = SavingGoal.None;

    public bool IsCompleted
    {
        get => DateTime.UtcNow > EndDate || SavingGoal.GoalIsReached();
        private set { }
    }

    public IEnumerable<Transaction> Transactions
    {
        get => _transactions;
        private set { _transactions = (List<Transaction>)value; }
    }

    public void AddTransaction(Transaction transaction)
    {
        if (transaction.TransactionDate < StartDate || transaction.TransactionDate > EndDate)
        {
            throw new InvalidOperationException("Transaction date is out of budget range");
        }

        _transactions.Add(transaction);

        UpdateSavingGoal(transaction);

        Raise(new TransactionAddedEvent(transaction.Id));
    }

    private void UpdateSavingGoal(Transaction transaction)
    {
        if (!SavingGoal.GoalIsReached())
            SavingGoal.UpdateReachAmount(transaction.TransactionType, transaction.Amount);
    }
}
