namespace ExpensesTrackerAPI.Core.Domain.Entities.Users.ValueObject;

public record Email(string Value, bool IsVerified)
{
    public static Email Empty() => new(string.Empty, false);
    public override string ToString()  => Value;
    public bool IsEmpty() => string.IsNullOrWhiteSpace(Value);
}
