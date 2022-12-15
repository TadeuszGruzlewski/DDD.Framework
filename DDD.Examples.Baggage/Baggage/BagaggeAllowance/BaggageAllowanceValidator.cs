using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class BaggageAllowanceValidator
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

    //protected override bool AssertInvariants(List<InvariantError> errors)
    //public bool IsBaggageAllowed(Baggage baggage, List<InvariantError> errors)
    //{
    //    var invariant = new BaggageInvariant(errors);

    //    var valid =
    //        invariant.IsAllowedNumber(Baggage.Accessories, Allowance.NumberOfAccessories) &&
    //        invariant.IsAllowedNumber(Baggage.HandBaggage, Allowance.NumberOfHandBaggages) &&
    //        invariant.IsAllowedNumber(Baggage.CheckedBaggage, Allowance.NumberOfCheckedBaggages) &&
    //        invariant.IsCabinAllowedWeight(Baggage.CabinBaggage, Allowance.WeightOfAllCabinBaggage);

    //    foreach (var item in Baggage.CheckedBaggage)
    //        valid &= invariant.IsCheckedAllowedWeight(item, Allowance.WeightOfOneCheckedBaggage);

    //    return valid;
    //}

    public static bool IsBaggageAllowed(List<InvariantError> errors, Baggage baggage, BaggageAllowance allowance)
    {
        var invariant = new BaggageInvariant(errors);

        var valid =
            invariant.IsAllowedNumber(baggage.Accessories, allowance.NumberOfAccessories) &&
            invariant.IsAllowedNumber(baggage.HandBaggage, allowance.NumberOfHandBaggages) &&
            invariant.IsAllowedNumber(baggage.CheckedBaggage, allowance.NumberOfCheckedBaggages) &&
            invariant.IsCabinAllowedWeight(baggage.CabinBaggage, allowance.WeightOfAllCabinBaggage);

        foreach (var item in baggage.CheckedBaggage)
            valid &= invariant.IsCheckedAllowedWeight(item, allowance.WeightOfOneCheckedBaggage);

        return valid;
    }
}
