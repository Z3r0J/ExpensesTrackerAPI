using System.Diagnostics.CodeAnalysis;

namespace ExpensesTrackerAPI.Core.Domain.Shared;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException("Cannot access value for a failed result");

    public static implicit operator Result<TValue>(TValue value) => Create(value);
}
