using ExpensesTrackerAPI.Core.Domain.Entities.Transactions;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Categories;

public sealed class Category : AggregateRoot
{
    private List<Transaction> _transactions = new();

    private Category(Guid id, string title, string description)
        : base(id)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }

    // Navigation properties

    public IEnumerable<Transaction> Transactions
    {
        get { return _transactions; }
        private set { _transactions = (List<Transaction>)value; }
    }

    public static Category Create(Guid id, string title, string description) =>
        new(id, title, description);
}
