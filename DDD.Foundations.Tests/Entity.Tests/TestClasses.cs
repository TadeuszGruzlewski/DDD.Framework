using DDD.Foundations;

namespace EntityTests;

public record class MyId(long Code) : EntityId
{
    public override bool IsValid() => true;
}

public class MyEntity : Entity<MyId>
{
    public int? Value { get; private set; }

    public MyEntity(MyId id, int? value = null) : base(id) => Value = value;

    protected override bool LocalValidate(NotificationCollector collector)
    {
        throw new System.NotImplementedException();
    }
}

//public class MyEntity<TId> : Entity<TId> where TId : MyId
//{
//    public int? Value { get; private set; }

//    public MyEntity(MyId id, int? value = null) : base((TId)id) => Value = value;

//    public static bool operator ==(MyEntity<TId> left, MyEntity<TId> right) => left.Value == right.Value;
//    public static bool operator !=(MyEntity<TId> left, MyEntity<TId> right) => left.Id != right.Id;
//}

public record class MyId1(long Code) : EntityId
{
    public override bool IsValid() => true;
}

public class MyEntity1 : Entity<MyId1>
{
    public int? Value { get; private set; }

    public MyEntity1(MyId1 id, int? value = null) : base(id) => Value = value;

    protected override bool LocalValidate(NotificationCollector collector)
    {
        throw new System.NotImplementedException();
    }
}
