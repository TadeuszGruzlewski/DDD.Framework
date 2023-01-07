
using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class CheckedItem(BaggageSize Size, decimal Weight, string Name, BaggageAllowance Allowance) : BaggageItem(Size, Weight, Name, Allowance)
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedSize(BaggageItem baggageItem)
        {
            var allowedSize = Allowance.CheckedItemSize;
            var valid = baggageItem.Size <= allowedSize;
            if (!valid)
                AddError($"Weight of {baggageItem.Name} exceeds the allowed limit of {allowedSize}.");
            return valid;
        }
        public bool IsAllowedWeight(BaggageItem baggageItem)
        {
            var allowedWeight = Allowance.WeightOfOneCheckedBaggage;
            var valid = baggageItem.Weight <= allowedWeight;
            if (!valid)
                AddError($"Weight of {baggageItem.Name} exceeds the allowed limit of {allowedWeight} kg.");
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
