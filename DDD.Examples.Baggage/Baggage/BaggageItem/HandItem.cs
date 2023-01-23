
using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class HandItem(Size Size, Weight Weight, string Name, BaggageAllowance Allowance) : BaggageItem(Size, Weight, Name, Allowance)
{
    private record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedSize(BaggageItem baggageItem)
        {
            var valid = baggageItem.Size <= Allowance.HandItemSize;
            if (!valid)
                AddError($"Item exceeds allowed {Allowance.HandItemSize}.");
            return valid;
        }
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var validator = new Validator(collector, Allowance);
        return validator.IsAllowedSize(this);
    }
}
