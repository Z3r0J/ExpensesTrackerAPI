namespace ExpensesTrackerAPI.Infrastructure.Persistence;

internal class PersistenceAssembly
{
    // Get the assembly of this class (ExpensesTrackerAPI.Infrastructure.Persistence)

    public static string? GetExecutingAssembly => System.Reflection.Assembly.GetAssembly(typeof(PersistenceAssembly))?.FullName;
}