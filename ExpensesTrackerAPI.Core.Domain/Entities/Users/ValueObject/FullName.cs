namespace ExpensesTrackerAPI.Core.Domain.Entities.Users.ValueObject;

public record FullName(string? FirstName, string LastName)
{
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public bool IsEmpty()
    {
        return string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(LastName);
    }
};
