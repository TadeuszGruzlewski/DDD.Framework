using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder : VOBuilder<Baggage>
{
    // valueObject is created in the base VOBuilder
    // its type is Baggage
    public BaggageBuilder(BaggageAllowance baggageAllowance, string valueObjectName) : base(valueObjectName)
    {
        valueObject!.SetAllowance(baggageAllowance);
    }

    public BaggageBuilder AddAccessory(BaggageSize size, Weight weight, string name)
    {
        valueObject!.AddAccessory(size, weight, name);
        return this;
    }

    public BaggageBuilder AddHandBaggage(BaggageSize size, Weight weight, string name)
    {
        valueObject!.AddHandBaggage(size, weight, name);
        return this;
    }

    public BaggageBuilder AddCheckedBaggage(BaggageSize size, Weight weight, string name)
    {
        valueObject!.AddCheckedBaggage(size, weight, name);
        return this;
    }
}
