using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class BaggageAllowanceValidator
{
    protected record class LocalValidator(NotificationCollector Collector) : InvariantValidator(Collector)
    {
        public bool IsAllowedNumber(List<BaggageItem> baggageItems, int allowedNumber)
        {
            var valid = baggageItems.Count <= allowedNumber;
            if (!valid)
                AddError(InvariantErrorCode.AboveMaximum, $"Number of baggage items exceeds the allowed limit.");
            return valid;
        }

        public bool IsCabinAllowedWeight(List<BaggageItem> baggageItems, decimal allowedWeight)
        {
            var totalWeight = baggageItems.Sum(w => w.Weight);
            var valid = totalWeight <= allowedWeight;
            if (!valid)
                AddError(InvariantErrorCode.AboveMaximum, $"Cabin baggage weight exceeds the allowed limit.");
            return valid;
        }

        public bool IsCheckedAllowedWeight(BaggageItem baggageItem, decimal allowedWeight)
        {
            var valid = baggageItem.Weight <= allowedWeight;
            if (!valid)
               AddError(InvariantErrorCode.AboveMaximum, $"Baggage item weight exceeds the allowed limit.");
            return valid;
        }
    }

    public static bool IsBaggageAllowed(NotificationCollector collector, Baggage baggage, BaggageAllowance allowance)
    {
        var validator = new LocalValidator(collector);

        var valid =
            validator.IsAllowedNumber(baggage.Accessories, allowance.NumberOfAccessories) &
            validator.IsAllowedNumber(baggage.HandBaggage, allowance.NumberOfHandBaggages) &
            validator.IsAllowedNumber(baggage.CheckedBaggage, allowance.NumberOfCheckedBaggages) &
            validator.IsCabinAllowedWeight(baggage.CabinBaggage, allowance.WeightOfAllCabinBaggage);

        foreach (var item in baggage.CheckedBaggage)
            valid &= validator.IsCheckedAllowedWeight(item, allowance.WeightOfOneCheckedBaggage);

        return valid;
    }
}
