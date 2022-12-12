using DDD.Foundations;

namespace DDD.Primitives.Finance;

public record class Money(Currency Currency, decimal Amount) : Primitive
{
    public override bool IsValid() => true;
}
