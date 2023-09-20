namespace ExpensesTrackerAPI.Core.Domain.Entities.Users.ValueObject;

public record Email(string Value, bool IsVerified)
{
    public static Email Empty()
    {
        return new(string.Empty, false);
    }

    public override string ToString()
    {
        return Value;
    }

    public bool IsEmpty()
    {
        return string.IsNullOrWhiteSpace(Value);
    }
}
