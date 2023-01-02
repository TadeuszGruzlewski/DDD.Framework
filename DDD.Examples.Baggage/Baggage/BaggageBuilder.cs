using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder : VOBuilder<Baggage>
{
    public BaggageBuilder SetAllowance(BaggageAllowance baggageAllowance)
    {
        valueObject!.SetAllowance(baggageAllowance);
        return this;
    }

    public BaggageBuilder AddAccessory(BaggageSize size, decimal weight, string description)
    {
        valueObject!.AddAccessory(size, weight, description);
        return this;
    }

    public BaggageBuilder AddHandBaggage(BaggageSize size, decimal weight, string description)
    {
        valueObject!.AddHandBaggage(size, weight, description);
        return this;
    }

    public BaggageBuilder AddCheckedBaggage(BaggageSize size, decimal weight, string description)
    {
        valueObject!.AddCheckedBaggage(size, weight, description);
        return this;
    }
}
