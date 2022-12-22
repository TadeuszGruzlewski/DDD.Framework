using System.Reflection;

namespace DDD.Foundations;

public abstract class EntityBuilder<E, I> : IEntityBuilder<E, I> where E : Entity<I> where I : EntityId
{
    protected readonly E? entity;

    // TODO - CreateInstance for internal constructor of entity
    public EntityBuilder(I id) =>
        entity = (E?)Activator.CreateInstance(typeof(E), new object[] { id });

    public readonly NotificationCollector Collector = new();

    public E? Build()
    {
        return entity;

        //Entity?.Validate(Collector, objectName);
        //return Collector.HasErrors ? null : entity;
    }
}
