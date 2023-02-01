
namespace DDD.Examples.Baggage;

public abstract record class BaggageAllowance
{
    public Size AccessoryItemSize = new(40, 30, 15);

    public Size HandItemSize = new(55, 35, 25);

    public int CheckedItemSize = 158; // sum of 3 dimensions

    public abstract int NumberOfAccessories { get; }
    public abstract int NumberOfHandItems { get; }
    public abstract int NumberOfCheckedItems { get; }

    public abstract Weight WeightOfAllCabinBaggage { get; }
    public abstract Weight WeightOfOneCheckedBaggage { get; }
}
