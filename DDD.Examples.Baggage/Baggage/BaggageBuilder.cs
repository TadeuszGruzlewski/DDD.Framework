using DDD.Foundations;

namespace DDD.Examples.Baggage;

public sealed class BaggageBuilder : VOBuilder<Baggage>
{
    public BaggageBuilder(BaggageAllowance allowance, string rootName) : base(rootName) =>
        Root.SetAllowance(allowance);

    // Root value object is assigned in the VOBuilder
    protected override Baggage CreateRoot(string rootName) => new(rootName);

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
