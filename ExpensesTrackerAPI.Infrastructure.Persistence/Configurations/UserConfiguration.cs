using ExpensesTrackerAPI.Core.Domain.Entities.Users;
using ExpensesTrackerAPI.Core.Domain.Entities.Users.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTrackerAPI.Infrastructure.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(properties => properties.Id)
            .HasConversion(x => x.Value,
                value => new UserId(value));

        builder.HasMany(x => x.Accounts)
            .WithOne()
            .HasForeignKey(account => account.UserId);

        builder.HasMany(user => user.Transactions)
            .WithOne()
            .HasForeignKey(transaction => transaction.UserId);

        builder.Property(x => x.Email)
            .HasMaxLength(400)
            .HasConversion(x => x.Value, value => new Email(value));

        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.FullName)
            .HasConversion(x => x.ToString(), name => new FullName(name.Split()[0], name.Split()[1]));
    }
}