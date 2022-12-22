using DDD.Foundations;

namespace EntityBuildersTests;

public record class MyId(long Code) : EntityId
{
    public override bool IsValid() => true;
}

public class MyEntity<TId> : Entity<TId> where TId : MyId
{
    // TODO - constructor should be internal
    public MyEntity(MyId id) : base((TId)id)
    { }
}

public class MyBuilder : EntityBuilder<MyEntity<MyId>, MyId>
{
    public MyBuilder(MyId id) : base(id)
    { }
}
