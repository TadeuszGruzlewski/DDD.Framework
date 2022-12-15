
namespace DDD.Examples.Baggage;

public abstract record class BaggageAllowance
{
    public abstract int NumberOfAccessories { get; }
    public abstract int NumberOfHandBaggages { get; }
    public abstract int NumberOfCheckedBaggages { get; }

    public abstract decimal WeightOfAllCabinBaggage { get; }
    public abstract decimal WeightOfOneCheckedBaggage { get; }
}
