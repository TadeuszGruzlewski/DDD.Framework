using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder : VOBuilder<Baggage>
{
    public BaggageBuilder(BaggageAllowance allowance, string rootName) : base(rootName) =>
        Root.SetAllowance(allowance);

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
