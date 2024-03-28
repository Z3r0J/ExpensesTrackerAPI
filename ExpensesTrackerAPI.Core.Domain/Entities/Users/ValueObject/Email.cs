namespace ExpensesTrackerAPI.Core.Domain.Entities.Users.ValueObject;

public record Email(string Value)
{
    public static Email Empty() => new(string.Empty);
    public override string ToString()  => Value;
    public bool IsEmpty() => string.IsNullOrWhiteSpace(Value);
}
