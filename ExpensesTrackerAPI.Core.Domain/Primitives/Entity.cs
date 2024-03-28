namespace ExpensesTrackerAPI.Core.Domain.Primitives;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
{
    protected Entity(TId id)
    {
        Id = id;
    }

    protected Entity() { }

    public TId Id { get; private init; } = default!;
    public DateTime? CreatedOnUtc { get; set; }
    public DateTime? UpdateOnUtc { get; set; }

    public static bool operator ==(Entity<TId>? first, Entity<TId>? second) =>
        first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity<TId>? first, Entity<TId>? second) => !(first == second);

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity<TId> entity)
        {
            return false;
        }

        return entity.Id is not null && entity.Id.Equals(Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return other.Id is not null && other.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        if (Id is not null) return Id.GetHashCode() * 41;

        return GetHashCode();
    }
}
