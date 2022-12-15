using DDD.Foundations;

namespace DDD.Primitives.Addresses;

public record class Country(int Code, string Name) : ValueObject
{
    protected override bool AssertInvariants(List<InvariantError> errors)
    {
        var invariant = new Invariant(errors);
        return invariant.IsPositiveInt(Code, nameof(Code)) &
               invariant.IsNotNullOrEmpty(Name, nameof(Name));
    }

    public override string ToString() => Name;
}
