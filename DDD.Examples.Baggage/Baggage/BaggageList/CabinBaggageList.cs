using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class CabinBaggageList : BaggageList
{
    protected record class LocalValidator(NotificationCollector Collector) : InvariantValidator(Collector)
    {
        public bool IsAllowedWeight(decimal weight, decimal allowedWeight)
        {
            var valid = weight <= allowedWeight;
            if (!valid)
                AddError($"Weight of cabin baggage exceeds the allowed limit of {allowedWeight} kg.");
            return valid;
        }
    }

    public IReadOnlyCollection<BaggageItem> Accessories => baggageItems.Where(b => b.GetType() == typeof(Accessory)).ToList();
    public IReadOnlyCollection<BaggageItem> HandBaggage => baggageItems.Where(b => b.GetType() == typeof(HandBaggage)).ToList();

    public decimal Weight => baggageItems.Sum(w => w.Weight);
    public int NumberOfAccessories => Accessories.Count;
    public int NumberOfHandBaggage => HandBaggage.Count;

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var result = base.LocalValidate(collector);

        var validator = new LocalValidator(collector);

        result &= validator.IsAllowedWeight(Weight, Allowance!.WeightOfAllCabinBaggage);

        return result;
    }
}
