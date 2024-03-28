﻿// <auto-generated />
using System;
using ExpensesTrackerAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpensesTrackerAPI.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateOnUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AccountId1");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CategoryId1");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Account", b =>
                {
                    b.HasOne("ExpensesTrackerAPI.Core.Domain.Entities.Users.User", null)
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ExpensesTrackerAPI.Core.Domain.Entities.Accounts.ValueObject.AccountBalanceInfo", "Balance", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("AccountId");

                            b1.ToTable("Accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");

                            b1.OwnsOne("ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject.Money", "CurrentAmount", b2 =>
                                {
                                    b2.Property<Guid>("AccountBalanceInfoAccountId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("decimal(18,2)");

                                    b2.Property<string>("Currency")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("AccountBalanceInfoAccountId");

                                    b2.ToTable("Accounts");

                                    b2.WithOwner()
                                        .HasForeignKey("AccountBalanceInfoAccountId");
                                });

                            b1.OwnsOne("ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject.Money", "TotalAmount", b2 =>
                                {
                                    b2.Property<Guid>("AccountBalanceInfoAccountId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("decimal(18,2)");

                                    b2.Property<string>("Currency")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("AccountBalanceInfoAccountId");

                                    b2.ToTable("Accounts");

                                    b2.WithOwner()
                                        .HasForeignKey("AccountBalanceInfoAccountId");
                                });

                            b1.Navigation("CurrentAmount")
                                .IsRequired();

                            b1.Navigation("TotalAmount")
                                .IsRequired();
                        });

                    b.Navigation("Balance")
                        .IsRequired();
                });

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Transaction", b =>
                {
                    b.HasOne("ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId1");

                    b.HasOne("ExpensesTrackerAPI.Core.Domain.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpensesTrackerAPI.Core.Domain.Entities.Categories.Category", null)
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId1");

                    b.HasOne("ExpensesTrackerAPI.Core.Domain.Entities.Users.User", null)
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ExpensesTrackerAPI.Core.Domain.Entities.Transactions.ValueObject.Money", "Amount", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TransactionId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.Navigation("Account");

                    b.Navigation("Amount")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Categories.Category", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ExpensesTrackerAPI.Core.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}