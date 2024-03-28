using ExpensesTrackerAPI.Core.Domain.Entities.Accounts;
using ExpensesTrackerAPI.Core.Domain.Entities.Categories;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTrackerAPI.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value,
                value => new TransactionId(value));

        builder.OwnsOne(x => x.Amount, propertyBuilder =>
        {
            propertyBuilder.Property(x => x.Currency)
                .HasConversion(x => x.Code, code => Currency.ExistingFromCode(code));
        });

        builder.Property(x => x.PaymentMethod)
            .HasConversion(x => x.ToString(),
                value => (PaymentMethod)
                    Enum.Parse(typeof(PaymentMethod), value)
            );

        builder.Property(x => x.TransactionType)
            .HasConversion(x => x.ToString(),
                value => (TransactionType)
                    Enum.Parse(typeof(TransactionType), value)
            );

        builder.Property(x => x.AccountId)
            .HasConversion(x => x.Value, value => new AccountId(value));

        builder.HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey(x => x.AccountId);

        builder.Property(x => x.CategoryId)
            .HasConversion(x => x.Value, value => new CategoryId(value));

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);
    }
}