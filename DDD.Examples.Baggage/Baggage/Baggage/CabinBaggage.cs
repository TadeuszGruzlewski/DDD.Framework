using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class CabinBaggage(BaggageAllowance Allowance, string Name) : ValueObject(Name)
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedWeight(Weight weight)
        {
            var allowedWeight = Allowance!.WeightOfAllCabinBaggage;
            var valid = weight <= allowedWeight;
            if (!valid)
                AddError($"Total weight {weight.Value} kg exceeds the allowed limit of {allowedWeight.Value} kg.");
            return valid;
        }
    }

    public readonly Accessories Accessories = new(Allowance, "Accessories");

    public readonly HandBaggage HandBaggage = new(Allowance, "Hand baggage");

    public void AddAccessory(Size size, Weight weight, string name) =>
        Accessories.AddAccessory(size, weight, name);
    public void AddHandBaggage(Size size, Weight weight, string name) => 
        HandBaggage.AddHandBaggage(size, weight, name);

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var validator = new Validator(collector, Allowance!);
        var weight = Accessories.Weight + HandBaggage.Weight;
        return
            validator.IsAllowedWeight(weight) &
            Accessories.Validate(collector) &
            HandBaggage.Validate(collector);
    }
}
