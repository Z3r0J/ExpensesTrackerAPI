using ExpensesTrackerAPI.Core.Domain.Entities.Categories.Events;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Categories;

public sealed class Category : AggregateRoot<CategoryId>
{
    private List<Transaction> _transactions = [];

    private Category() { }

    private Category(CategoryId id, string title, string description)
        : base(id)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    // Navigation properties

    public IEnumerable<Transaction> Transactions
    {
        get => _transactions;
        private set => _transactions = (List<Transaction>)value;
    }

    public static Category Create(string title, string description)
    {
        var id = CategoryId.New;

        Raise(new CategoryCreatedEvent(id.Id));

        return new(id, title, description);
    }

    public void Update(string? title, string? description)
    {
        Title = title ?? Title;
        Description = description ?? Description;

        Raise(new CategoryUpdatedEvent(Id.Id));
    }
}
