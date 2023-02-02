
namespace DDD.Foundations;

public abstract class EntityBuilder<TEntity, TEntityId> where TEntity : Entity<TEntityId> where TEntityId : EntityId
{
    protected TEntity Root;

    // TODO similar to VOBuider
    public EntityBuilder(TEntityId id)
    {
    }

    public NotificationCollector NotificationCollector { get; } = new();

    public TEntity? Build()
    {
        Root.Validate(NotificationCollector, ""); // TEntityId.AsString);
        return NotificationCollector.HasErrors ? null : Root;
    }
}
