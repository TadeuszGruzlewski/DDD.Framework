using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class CabinBaggageList : BaggageList
{
    protected record class LocalValidator(NotificationCollector Collector) : InvariantValidator(Collector)
    {
        public bool IsAllowedWeight(List<BaggageItem> baggageItems, decimal allowedWeight, string fieldName)
        {
            var totalWeight = baggageItems.Sum(w => w.Weight);
            var valid = totalWeight <= allowedWeight;
            if (!valid)
                AddError($"Weight of cabin baggage exceeds the allowed limit of {allowedWeight} kg.");
            return valid;
        }
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var result = base.LocalValidate(collector);

        var validator = new LocalValidator(collector);

        result &= validator.IsAllowedWeight(baggageItems, Allowance!.WeightOfAllCabinBaggage, "Cabin baggage");

        return result;
    }
}
