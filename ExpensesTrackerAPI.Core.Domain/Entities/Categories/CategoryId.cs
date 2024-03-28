namespace ExpensesTrackerAPI.Core.Domain.Entities.Categories;

public readonly record struct CategoryId(Guid Value)
{
    public static CategoryId Empty => new(Guid.Empty);
    public static CategoryId New => new(Guid.NewGuid());
}