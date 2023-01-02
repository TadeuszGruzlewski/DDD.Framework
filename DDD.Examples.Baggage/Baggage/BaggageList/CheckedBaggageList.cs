using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class CheckedBaggageList : BaggageList
{
    protected record class LocalValidator(NotificationCollector Collector) : InvariantValidator(Collector)
    {
        public bool IsAllowedWeight(BaggageItem baggageItem, decimal allowedWeight, string fieldName)
        {
            var valid = baggageItem.Weight <= allowedWeight;
            if (!valid)
                AddError(InvariantErrorCode.AboveMaximum, fieldName, $"Weight of checked baggage exceeds the allowed limit of {allowedWeight} kg.");
            return valid;
        }
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var result = base.LocalValidate(collector);

        var validator = new LocalValidator(collector);

        foreach (var item in baggageItems)
            result &= validator.IsAllowedWeight(item, Allowance!.WeightOfOneCheckedBaggage, item.Name!);

        return result;
    }
}
