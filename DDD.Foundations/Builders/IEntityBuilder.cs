namespace DDD.Foundations;

public interface IEntityBuilder<E, I> where E : Entity<I> where I : EntityId
{
    E? Build(string objectName);
}
