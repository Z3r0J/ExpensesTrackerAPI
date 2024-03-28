namespace ExpensesTrackerAPI.Core.Domain.Entities.Categories;

public record CategoryId(Guid Id)
{
    public static CategoryId Empty => new(Guid.Empty);
    public static CategoryId New => new(Guid.NewGuid());
}