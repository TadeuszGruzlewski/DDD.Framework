using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder<T> : VOBuilder<T> where T : Baggage
{
    public BaggageBuilder(string objectName) : base(objectName)
    { }

    public BaggageBuilder<T> SetAllowance(BaggageAllowance baggageAllowance)
    {
        ValueObject!.Allowance = baggageAllowance;
        return this;
    }

    public BaggageBuilder<T> AddAccessory(BaggageSize size, decimal weight, string description)
    {
        Accessory accessory = new(size, weight, description);
        ValueObject!.AddBaggageItem(accessory);
        return this;
    }

    public BaggageBuilder<T> AddHandBaggage(BaggageSize size, decimal weight, string description)
    {
        HandBaggage handBaggage = new(size, weight, description);
        ValueObject!.AddBaggageItem(handBaggage);
        return this;
    }

    public BaggageBuilder<T> AddCheckedBaggage(BaggageSize size, decimal weight, string description)
    {
        CheckedBaggage checkedBaggage = new(size, weight, description);
        ValueObject!.AddBaggageItem(checkedBaggage);
        return this;
    }
}
