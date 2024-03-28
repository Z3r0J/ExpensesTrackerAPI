using ExpensesTrackerAPI.Core.Domain.Entities.Accounts;
using ExpensesTrackerAPI.Core.Domain.Entities.Categories;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions;
using ExpensesTrackerAPI.Core.Domain.Entities.Users;
using ExpensesTrackerAPI.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Infrastructure.Persistence.Contexts;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; } = default!;
    public DbSet<Category> Categories { get; } = default!;
    public DbSet<Transaction> Transactions { get; } = default!;
    public DbSet<Account> Accounts { get; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (ConfigurationAssembly.GetExecutingAssembly is not null) modelBuilder.ApplyConfigurationsFromAssembly(ConfigurationAssembly.GetExecutingAssembly);

        base.OnModelCreating(modelBuilder);
    }
}