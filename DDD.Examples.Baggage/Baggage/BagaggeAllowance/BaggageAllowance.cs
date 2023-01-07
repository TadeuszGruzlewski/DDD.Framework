
namespace DDD.Examples.Baggage;

public abstract record class BaggageAllowance
{
    public BaggageSize AccessoryItemSize = new(40, 30, 15);

    public BaggageSize HandItemSize = new(55, 35, 25);

    public int CheckedItemSize = 158;

    public abstract int NumberOfAccessories { get; }
    public abstract int NumberOfHandBaggages { get; }
    public abstract int NumberOfCheckedBaggages { get; }

    public abstract decimal WeightOfAllCabinBaggage { get; }
    public abstract decimal WeightOfOneCheckedBaggage { get; }
}
