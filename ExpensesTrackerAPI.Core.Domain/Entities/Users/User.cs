using ExpensesTrackerAPI.Core.Domain.Entities.Accounts;
using ExpensesTrackerAPI.Core.Domain.Entities.Accounts.Events;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions;
using ExpensesTrackerAPI.Core.Domain.Entities.Transactions.Events;
using ExpensesTrackerAPI.Core.Domain.Entities.Users.Enums;
using ExpensesTrackerAPI.Core.Domain.Entities.Users.Events;
using ExpensesTrackerAPI.Core.Domain.Entities.Users.ValueObject;
using ExpensesTrackerAPI.Core.Domain.Primitives;

namespace ExpensesTrackerAPI.Core.Domain.Entities.Users;

public class User : AggregateRoot
{
    private List<Transaction> _transactions = new();
    private List<Account> _accounts = new();

    public User(
        Guid id,
        FullName fullName,
        Email email,
        Roles rol,
        string userName,
        string password
    )
        : base(id)
    {
        FullName = fullName;
        Email = email;
        Rol = rol;
        UserName = userName;
        Password = password;
    }

    public FullName FullName { get; private set; } = new(string.Empty, string.Empty);
    public Email Email { get; private set; } = Email.Empty();
    public string UserName { get; private set; } = string.Empty;
    public Roles Rol { get; private set; } = Roles.User;
    public string Password { get; private set; } = string.Empty;

    // Navigation properties

    public IEnumerable<Transaction> Transactions
    {
        get { return _transactions; }
        private set { _transactions = (List<Transaction>)value; }
    }

    public IEnumerable<Account> Accounts
    {
        get { return _accounts; }
        private set { _accounts = (List<Account>)value; }
    }

    //Factory Methods

    public static User Create(
        Guid id,
        FullName fullName,
        Email email,
        Roles rol,
        string userName,
        string password
    )
    {
        User user = new(id, fullName, email, rol, userName, password);

        Raise(new UserCreatedEvent(id));

        return user;
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        Raise(new TransactionAddedEvent(transaction.Id));
    }

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
        Raise(new AccountCreatedEvent(account.Id));
    }

    public void RemoveTransaction(Transaction transaction)
    {
        if (_transactions.Count > 0 && _transactions.Any(tr => tr.Equals(transaction)))
        {
            _transactions.Remove(transaction);
        }

        throw new InvalidOperationException("Transaction not found");
    }

    public void RemoveAccount(Account account)
    {
        if (_accounts.Count > 0 && _accounts.Any(acc => acc.Equals(account)))
        {
            _accounts.Remove(account);
        }

        throw new InvalidOperationException("Account not found");
    }

    public void Update(
        FullName? fullName,
        Email? email,
        Roles? rol,
        string? userName,
        string? password
    )
    {
        FullName = fullName ?? FullName;
        Email = email ?? Email;
        UserName = userName ?? UserName;
        Password = password ?? Password;
        Rol = rol ?? Rol;

        Raise(new UserUpdatedEvent(Id));
    }
}
