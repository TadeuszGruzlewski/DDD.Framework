using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder : VOBuilder<Baggage>
{
     public BaggageBuilder SetAllowance(BaggageAllowance baggageAllowance)
    {
        ValueObject!.Allowance = baggageAllowance;
        return this;
    }

    public BaggageBuilder AddAccessory(BaggageSize size, decimal weight, string description)
    {
        Accessory accessory = new(size, weight, description);
        ValueObject!.AddBaggageItem(accessory);
        return this;
    }

    public BaggageBuilder AddHandBaggage(BaggageSize size, decimal weight, string description)
    {
        HandBaggage handBaggage = new(size, weight, description);
        ValueObject!.AddBaggageItem(handBaggage);
        return this;
    }

    public BaggageBuilder AddCheckedBaggage(BaggageSize size, decimal weight, string description)
    {
        CheckedBaggage checkedBaggage = new(size, weight, description);
        ValueObject!.AddBaggageItem(checkedBaggage);
        return this;
    }
}
