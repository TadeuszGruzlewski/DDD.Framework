using DDD.Foundations;

namespace DDD.Examples.Baggage;

public sealed class BaggageBuilder : VOBuilder<Baggage>
{
    // valueObject is created in the base VOBuilder through delegation to Create method
    public BaggageBuilder(BaggageAllowance baggageAllowance, string valueObjectName) : base(valueObjectName) =>
        valueObject!.SetAllowance(baggageAllowance);

    protected override Baggage Create(string valueObjectName) => new(valueObjectName);

    public BaggageBuilder AddAccessory(Size size, Weight weight, string name)
    {
        valueObject!.AddAccessory(size, weight, name);
        return this;
    }

    public BaggageBuilder AddHandBaggage(Size size, Weight weight, string name)
    {
        valueObject!.AddHandBaggage(size, weight, name);
        return this;
    }

    public BaggageBuilder AddCheckedBaggage(Size size, Weight weight, string name)
    {
        valueObject!.AddCheckedBaggage(size, weight, name);
        return this;
    }
}
