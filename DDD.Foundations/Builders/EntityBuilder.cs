
namespace DDD.Foundations;

public abstract class EntityBuilder<E, I> : IEntityBuilder<E, I> where E : Entity<I> where I : EntityId
{
    protected readonly E? entity;

    // TODO - CreateInstance for internal constructor of entity
    public EntityBuilder(I id)
    {
        NotificationCollector = new();// new(id is null ? "" : id.ToString());
        var validator = new InvariantValidator(NotificationCollector);
        var valid = validator.IsNotNullReference(id, "Id");
        if (valid)
            entity = (E?)Activator.CreateInstance(typeof(E), new object[] { id! });
    }

    public NotificationCollector NotificationCollector { get; private set; }

    public E? Build(string objectName)
    {
        entity?.Validate(NotificationCollector, objectName);
        return NotificationCollector.HasErrors ? null : entity;
    }
}
