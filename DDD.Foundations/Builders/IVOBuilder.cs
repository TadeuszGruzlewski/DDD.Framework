namespace DDD.Foundations;

public interface IVOBuilder<TValueObject> where TValueObject : ValueObject
{
    TValueObject? Build();
}
