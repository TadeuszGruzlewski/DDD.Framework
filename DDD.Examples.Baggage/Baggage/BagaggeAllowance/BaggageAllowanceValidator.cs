using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class BaggageAllowanceValidator
{
    protected record class LocalValidator(NotificationCollector Collector) : InvariantValidator(Collector)
    {
        public bool IsAllowedNumber(List<BaggageItem> baggageItems, int allowedNumber, string fieldName)
        {
            var valid = baggageItems.Count <= allowedNumber;
            if (!valid)
                AddError(InvariantErrorCode.AboveMaximum, fieldName, $"Number of baggage items exceeds the allowed limit of {allowedNumber} items.");
            return valid;
        }

        public bool IsCabinAllowedWeight(List<BaggageItem> baggageItems, decimal allowedWeight, string fieldName)
        {
            var totalWeight = baggageItems.Sum(w => w.Weight);
            var valid = totalWeight <= allowedWeight;
            if (!valid)
                AddError(InvariantErrorCode.AboveMaximum, fieldName, $"Weight of cabin baggage exceeds the allowed limit of {allowedWeight} kg.");
            return valid;
        }

        public bool IsCheckedAllowedWeight(BaggageItem baggageItem, decimal allowedWeight, string fieldName)
        {
            var valid = baggageItem.Weight <= allowedWeight;
            if (!valid)
               AddError(InvariantErrorCode.AboveMaximum, fieldName, $"Weight of checked baggage exceeds the allowed limit of {allowedWeight} kg.");
            return valid;
        }
    }

    public static bool IsBaggageAllowed(NotificationCollector collector, Baggage baggage, BaggageAllowance allowance)
    {
        var validator = new LocalValidator(collector);

        var valid =
            validator.IsAllowedNumber(baggage.Accessories, allowance.NumberOfAccessories, "Accessories") &
            validator.IsAllowedNumber(baggage.HandBaggage, allowance.NumberOfHandBaggages, "Hand Baggage") &
            validator.IsAllowedNumber(baggage.CheckedBaggage, allowance.NumberOfCheckedBaggages, "Checked Baggage") &
            validator.IsCabinAllowedWeight(baggage.CabinBaggage, allowance.WeightOfAllCabinBaggage, "Cabin Baggage");

        foreach (var item in baggage.CheckedBaggage)
            valid &= validator.IsCheckedAllowedWeight(item, allowance.WeightOfOneCheckedBaggage, item.Description);

        return valid;
    }
}
