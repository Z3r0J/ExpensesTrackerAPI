namespace ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;

public record Currency
{
    internal static Currency None = new(string.Empty);
    public static readonly Currency EUR = new("EUR");
    public static readonly Currency USD = new("USD");
    public static readonly Currency DOP = new("DOP");

    private Currency(string code) => Code = code;

    public string Code { get; init; }

    public static Currency ExistingFromCode(string code)
    {
        return All.FirstOrDefault(x => x.Code == code) ?? None;
    }

    private static IReadOnlyCollection<Currency> All => new List<Currency> { EUR, USD, DOP };
}
