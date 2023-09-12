using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities;

public sealed class TransactionType : AggregateRoot
{
    private List<Transaction> _transactions = new();

    private TransactionType(Guid id, string name)
        : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;

    // Navigation properties

    public IEnumerable<Transaction> Transactions
    {
        get { return _transactions; }
        private set { _transactions = (List<Transaction>)value; }
    }

    public static TransactionType Create(Guid id, string name) => new(id, name);
}
