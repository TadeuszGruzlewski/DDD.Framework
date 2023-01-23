
namespace DDD.Examples.Baggage;

public abstract record class BaggageAllowance
{
    public Size AccessoryItemSize = new(40, 30, 15);

    public Size HandItemSize = new(55, 35, 25);

    public int CheckedItemSize = 158;

    public abstract int NumberOfAccessories { get; }
    public abstract int NumberOfHandBaggages { get; }
    public abstract int NumberOfCheckedBaggages { get; }

    public abstract Weight WeightOfAllCabinBaggage { get; }
    public abstract Weight WeightOfOneCheckedBaggage { get; }
}
