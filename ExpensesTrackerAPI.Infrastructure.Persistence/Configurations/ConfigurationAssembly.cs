using System.Reflection;

namespace ExpensesTrackerAPI.Infrastructure.Persistence.Configurations;

internal class ConfigurationAssembly
{
    public static Assembly? GetExecutingAssembly => System.Reflection.Assembly.GetAssembly(typeof(ConfigurationAssembly));
}