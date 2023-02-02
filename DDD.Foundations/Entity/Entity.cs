using System.Xml.Linq;

namespace DDD.Foundations;

public abstract class Entity<TEntityId> where TEntityId : EntityId
{
    public TEntityId Id { get; init; }

    protected Entity(TEntityId id)
    {
        if (id is null)
            throw new ArgumentNullException(nameof(id));
        Id = id;
    }

    public bool? IsValid { get; private set; }

    protected abstract bool LocalValidate(NotificationCollector collector);

    public bool Validate(NotificationCollector collector, string scopeName)
    {
        // validated already? - circuit breaker
        if (IsValid is null)
        {
            collector.EnterSubscope(scopeName);
            IsValid = LocalValidate(collector);
            collector.ExitSubscope();
        }
        return (bool)IsValid;
    }

    //We follow the Microsoft semantics.
    //Lifted == operator considers two null values equal, 
    //and a null value unequal to any non-null value.
    //If both operands are non-null, the lifted operator unwraps the operands
    //and applies the underlying operator to produce the bool result.
    public static bool? operator ==(Entity<TEntityId>? e1, Entity<TEntityId>? e2) =>
        e1 is null && e2 is null || e1 is not null && e1.Equals(e2);
    public static bool? operator !=(Entity<TEntityId>? e1, Entity<TEntityId>? e2) => !(e1 == e2);

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if (GetType() != obj.GetType())
            return false;
        var entity = (Entity<TEntityId>)obj;
        return Id == entity.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}
