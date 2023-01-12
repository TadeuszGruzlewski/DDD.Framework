using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class CabinBaggage(BaggageAllowance Allowance) : ValueObject
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedWeight(Weight weight)
        {
            var allowedWeight = Allowance!.WeightOfAllCabinBaggage;
            var valid = weight <= allowedWeight;
            if (!valid)
                AddError($"Total weight {weight} kg exceeds the allowed limit of {allowedWeight} kg.");
            return valid;
        }
    }

    public readonly Accessories Accessories = new(Allowance);

    public readonly HandBaggage HandBaggage = new(Allowance);

    public void AddAccessory(BaggageSize size, Weight weight, string description) =>
        Accessories.AddAccessory(size, weight, description);
    public void AddHandBaggage(BaggageSize size, Weight weight, string description) =>
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
