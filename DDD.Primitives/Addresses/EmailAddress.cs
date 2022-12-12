using DDD.Foundations;

namespace DDD.Primitives.Addresses;

public record class EmailAddress(string Address) : Primitive
{
    public override bool IsValid()
    {
        // TODO regex validation
        throw new NotImplementedException();
    }
}
