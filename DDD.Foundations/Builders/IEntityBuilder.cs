namespace DDD.Foundations;

public interface IEntityBuilder<TEntity, TEntityId> where TEntity : Entity<TEntityId> where TEntityId : EntityId
{
    TEntity? Build();
}
