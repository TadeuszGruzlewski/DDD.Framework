namespace DDD.Foundations;

public abstract class EntityBuilder<E, EI> : IEntityBuilder<E, EI> where E : Entity<EI>, new() where EI : EntityId
{
    private readonly E entity;
    public EntityBuilder(EI id) => entity = new E() { Id = id };

    public E Build() => entity;
}
