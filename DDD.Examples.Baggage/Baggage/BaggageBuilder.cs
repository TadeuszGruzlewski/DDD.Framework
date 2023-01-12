using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder : VOBuilder<Baggage>
{
    // valueObject is created in the base VOBuilder
    // its type is Baggage
    public BaggageBuilder(BaggageAllowance baggageAllowance)
    {
        valueObject!.SetAllowance(baggageAllowance);
    }

    public BaggageBuilder AddAccessory(BaggageSize size, Weight weight, string description)
    {
        valueObject!.AddAccessory(size, weight, description);
        return this;
    }

    public BaggageBuilder AddHandBaggage(BaggageSize size, Weight weight, string description)
    {
        valueObject!.AddHandBaggage(size, weight, description);
        return this;
    }

    public BaggageBuilder AddCheckedBaggage(BaggageSize size, Weight weight, string description)
    {
        valueObject!.AddCheckedBaggage(size, weight, description);
        return this;
    }
}
