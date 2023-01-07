using DDD.Foundations;

namespace DDD.Examples.Baggage;

internal record class CabinBaggage(BaggageAllowance Allowance) : ValueObject
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedWeight(decimal weight)
        {
            var allowedWeight = Allowance!.WeightOfAllCabinBaggage;
            var valid = weight <= allowedWeight;
            if (!valid)
                AddError($"Total weight exceeds the allowed limit of {allowedWeight} kg.");
            return valid;
        }
    }

    private readonly Accessories Accessories = new(Allowance);

    private readonly HandBaggage HandBaggage = new(Allowance);

    public void AddAccessory(BaggageSize size, decimal weight, string description) =>
        Accessories.AddAccessory(size, weight, description);
    public void AddHandBaggage(BaggageSize size, decimal weight, string description) =>
        HandBaggage.AddHandBaggage(size, weight, description);

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var validator = new Validator(collector, Allowance!);
        var weight = Accessories.Weight + HandBaggage.Weight;
        return
            validator.IsAllowedWeight(weight) &
            Accessories.Validate(collector, "Accessories") &
            HandBaggage.Validate(collector, "Hand baggage");
    }
}
