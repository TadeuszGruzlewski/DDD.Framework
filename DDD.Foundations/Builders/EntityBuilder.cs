
namespace DDD.Foundations;

public abstract class EntityBuilder<E, I> : IEntityBuilder<E, I> where E : Entity<I> where I : EntityId
{
    protected readonly E? entity;

    // TODO - CreateInstance for internal constructor of entity
    public EntityBuilder(I id)
    {
        if (id is null)
            throw new ArgumentNullException(nameof(id));
        entity = (E?)Activator.CreateInstance(typeof(E), new object[] { id! });
    }

    public NotificationCollector NotificationCollector { get; } = new();

    public E? Build()
    {
        entity?.Validate(NotificationCollector, entity.Id.ToString());
        return NotificationCollector.HasErrors ? null : entity;
    }
}
