using DDD.Foundations;

namespace DDD.Examples.Baggage;

public sealed class BaggageBuilder : VOBuilder<Baggage>
{
    // Root value object is created in the base VOBuilder through delegation to the Create method
    public BaggageBuilder(BaggageAllowance allowance, string rootName) : base(rootName) =>
        Root.SetAllowance(allowance);

    protected override Baggage Create(string rootName) => new(rootName);

    public BaggageBuilder AddAccessory(Size size, Weight weight, string name)
    {
        Root.AddAccessory(size, weight, name);
        return this;
    }

    public BaggageBuilder AddHandBaggage(Size size, Weight weight, string name)
    {
        Root.AddHandBaggage(size, weight, name);
        return this;
    }

    public BaggageBuilder AddCheckedBaggage(Size size, Weight weight, string name)
    {
        Root.AddCheckedBaggage(size, weight, name);
        return this;
    }
}
