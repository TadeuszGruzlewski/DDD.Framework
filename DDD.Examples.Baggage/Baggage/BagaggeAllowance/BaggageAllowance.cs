using DDD.Foundations;

namespace DDD.Examples.Baggage;

public abstract class BaggageAllowance : IBaggageAllowance
{
    protected record class BaggageInvariant(List<InvariantError> Errors) : Invariant(Errors)
    {
        public bool IsAllowedNumber(List<BaggageItem> baggageItems, int allowedNumber)
        {
            var valid = baggageItems.Count <= allowedNumber;
            if (!valid)
                Errors.Add(new(InvariantErrorCode.OutsideRange, $"Number of baggage items exceeds the allowed limit."));
            return valid;
        }

        public bool IsCabinAllowedWeight(List<BaggageItem> baggageItems, decimal allowedWeight)
        {
            var totalWeight = baggageItems.Sum(w => w.Weight);
            var valid = totalWeight <= allowedWeight;
            if (!valid)
                Errors.Add(new(InvariantErrorCode.OutsideRange, $"Cabin baggage weight exceeds the allowed limit."));
            return valid;
        }

        public bool IsCheckedAllowedWeight(BaggageItem baggageItem, decimal allowedWeight)
        {
            var valid = baggageItem.Weight <= allowedWeight;
            if (!valid)
                Errors.Add(new(InvariantErrorCode.OutsideRange, $"Baggage item weight exceeds the allowed limit."));
            return valid;
        }
    }

    public abstract int AllowedNumberOfAccessories { get; }
    public abstract int AllowedNumberOfHandBaggages { get; }
    public abstract int AllowedNumberOfCheckedBaggages { get; }

    public abstract decimal AllowedWeightOfAllCabinBaggage { get; }
    public abstract decimal AllowedWeightOfOneCheckedBaggage { get; }

    public bool IsBaggageAllowed(Baggage baggage, List<InvariantError> errors)
    {
        var invariant = new BaggageInvariant(errors);

        var valid =
            invariant.IsAllowedNumber(baggage.Accessories, AllowedNumberOfAccessories) &&
            invariant.IsAllowedNumber(baggage.HandBaggage, AllowedNumberOfHandBaggages) &&
            invariant.IsAllowedNumber(baggage.CheckedBaggage, AllowedNumberOfCheckedBaggages) &&
            invariant.IsCabinAllowedWeight(baggage.CabinBaggage, AllowedWeightOfAllCabinBaggage);

        foreach(var item in baggage.CheckedBaggage)
            valid &= invariant.IsCheckedAllowedWeight(item, AllowedWeightOfOneCheckedBaggage);

        return valid;
    }
}
