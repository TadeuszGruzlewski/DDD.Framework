using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BaggageBuilder<T> : VOBuilder<T> where T : Baggage
{
    public BaggageBuilder<T> SetAllowance(IBaggageAllowance baggageAllowance)
    {
        ValueObject!.Allowance = baggageAllowance;
        return this;
    }

    public BaggageBuilder<T> AddAccessory(BaggageSize size, decimal weight)
    {
        Accessory accessory = new(size, weight);
        ValueObject!.AddBaggageItem(accessory);
        return this;
    }

    public BaggageBuilder<T> AddHandBaggage(BaggageSize size, decimal weight)
    {
        HandBaggage handBaggage = new(size, weight);
        ValueObject!.AddBaggageItem(handBaggage);
        return this;
    }

    public BaggageBuilder<T> AddCheckedBaggage(BaggageSize size, decimal weight)
    {
        CheckedBaggage checkedBaggage = new(size, weight);
        ValueObject!.AddBaggageItem(checkedBaggage);
        return this;
    }
}
