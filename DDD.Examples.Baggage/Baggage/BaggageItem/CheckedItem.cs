
using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class CheckedItem(Size Size, Weight Weight, string Name, BaggageAllowance Allowance) : BaggageItem(Size, Weight, Name, Allowance)
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedSize(BaggageItem baggageItem)
        {
            var allowedSize = Allowance.CheckedItemSize;
            var valid = baggageItem.Size <= allowedSize;
            if (!valid)
                AddError($"Sum of dimensions exceeds the allowed limit of {allowedSize} cm.");
            return valid;
        }
        public bool IsAllowedWeight(BaggageItem baggageItem)
        {
            var allowedWeight = Allowance.WeightOfOneCheckedBaggage;
            var valid = baggageItem.Weight <= allowedWeight;
            if (!valid)
                AddError($"Weight {baggageItem.Weight.Value} kg exceeds the allowed limit of {allowedWeight.Value} kg.");
            return valid;
        }
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var validator = new Validator(collector, Allowance);
        return 
            validator.IsAllowedSize(this) &
            validator.IsAllowedWeight(this);
    }
}
