using DDD.Primitives.Quantities;
using DDD.Primitives.DimensionUoMs;

namespace DDD.Primitives.Dimensions;

public record class Volume : Quantity
{
    public Volume(VolumeUoM uom, decimal amount) => (UoM, Amount) = (uom, amount);

    public static readonly Volume Zero = new(VolumeUoM.None, 0);

    protected override bool IsNone() => UoM == VolumeUoM.None;
}
