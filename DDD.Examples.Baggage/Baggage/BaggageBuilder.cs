using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder : VOBuilder<Baggage>
{
    // valueObject is created in the base VOBuilder through delegation to Create method
    public BaggageBuilder(BaggageAllowance baggageAllowance, string valueObjectName) : base(valueObjectName) =>
        valueObject!.SetAllowance(baggageAllowance);

    protected override Baggage Create(string valueObjectName) => new(valueObjectName);

    //protected override Func<Baggage> Create(string valueObjectName) =>
    //    () => new Baggage(valueObjectName);

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
