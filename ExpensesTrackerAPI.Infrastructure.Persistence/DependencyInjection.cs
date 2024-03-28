using ExpensesTrackerAPI.Core.Domain.Entities.Options;
using ExpensesTrackerAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesTrackerAPI.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);

        return services;
    }


    private static void AddPersistence(this IServiceCollection service, IConfiguration configuration)
    {
        DatabaseConfiguration databaseConfiguration = new();

        configuration.GetSection(nameof(databaseConfiguration)).Bind(databaseConfiguration);

        if (databaseConfiguration is { Provider: "MSSQL", UseInMemory: false })
            service.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(databaseConfiguration.ConnectionString,
                    sqlServerOptions =>
                    {
                        sqlServerOptions.MigrationsAssembly(PersistenceAssembly.GetExecutingAssembly);
                    });
            });
    }
}