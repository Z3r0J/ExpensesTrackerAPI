namespace ExpensesTrackerAPI.Core.Domain.Entities.Options;

public class DatabaseConfiguration
{
    public string Provider { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public bool UseInMemory { get; set; } = false;
}