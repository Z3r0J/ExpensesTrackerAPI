using ExpensesTrackerAPI.Core.Domain.Entities.Accounts;
using ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTrackerAPI.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value,
                value => new AccountId(value));

        builder.OwnsOne(x => x.Balance, balanceBuilder =>
        {
            balanceBuilder.OwnsOne(x => x.TotalAmount, totalAmountBuilder =>
            {
                totalAmountBuilder.Property(x => x.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.ExistingFromCode(code));
            });

            balanceBuilder.OwnsOne(x => x.CurrentAmount, currentAmountBuilder =>
            {
                currentAmountBuilder.Property(x => x.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.ExistingFromCode(code));
            });
        });

        builder.Property(x => x.AccountType)
            .HasConversion(x => x.ToString(), value =>
                (AccountType)Enum.Parse(typeof(AccountType), value));
    }
}