using DDD.Primitives.Quantities;
using DDD.Primitives.DimensionUoMs;

namespace DDD.Primitives.Dimensions;

public record class Area : Quantity
{
    public Area(AreaUoM uom, decimal amount) => (UoM, Amount) = (uom, amount);

    public static readonly Area Zero = new(AreaUoM.None, 0);

    protected override bool IsNone() => UoM == AreaUoM.None;

    // TODO
    public static Volume operator *(Area l1, Length l2)
    {
        if (l1.IsZero | l2.IsZero)
            return Volume.Zero;
        // TestUoMs(l1, l2)
        // TODO - l1.UoM ^ 2
        return (Volume)Create(typeof(Area), l1.UoM!, l1.Amount * l2.Amount)!;
    }
}
