using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder : VOBuilder<Baggage>
{
     public BaggageBuilder SetAllowance(BaggageAllowance baggageAllowance)
    {
        valueObject!.Allowance = baggageAllowance;
        return this;
    }

    public BaggageBuilder AddAccessory(BaggageSize size, decimal weight, string description)
    {
        Accessory accessory = new(size, weight, description);
        valueObject!.AddBaggageItem(accessory);
        return this;
    }

    public BaggageBuilder AddHandBaggage(BaggageSize size, decimal weight, string description)
    {
        HandBaggage handBaggage = new(size, weight, description);
        valueObject!.AddBaggageItem(handBaggage);
        return this;
    }

    public BaggageBuilder AddCheckedBaggage(BaggageSize size, decimal weight, string description)
    {
        CheckedBaggage checkedBaggage = new(size, weight, description);
        valueObject!.AddBaggageItem(checkedBaggage);
        return this;
    }
}
