using DDD.Foundations;

namespace DDD.Examples.Baggage;

public abstract record class BaggageItem(BaggageSize Size, decimal Weight) : ValueObject
{
    private record class BaggageInvariant(List<InvariantError> Errors) : Invariant(Errors)
    {
        public bool IsAllowedSize(BaggageItem baggageItem)
        {
            var valid = baggageItem.IsAllowedSize();
            if (!valid)
                Errors.Add(new(InvariantErrorCode.OutsideRange, $"Baggage size exceeds allowed dimensions."));
            return valid;
        }
    }

    public abstract bool IsAllowedSize();

    public override bool AssertInvariants(List<InvariantError> errors)
    {
        var invariant = new BaggageInvariant(errors);
        return invariant.IsAllowedSize(this);
    }
}
