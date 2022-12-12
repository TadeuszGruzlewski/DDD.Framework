using DDD.Primitives.Quantities;
using DDD.Primitives.DimensionUoMs;

namespace DDD.Primitives.Dimensions;

public record class Length : Quantity
{
    public Length(LengthUoM uom, decimal amount) => (UoM, Amount) = (uom, amount);

    public static readonly Length Zero = new(LengthUoM.None, 0);

    protected override bool IsNone() => UoM == LengthUoM.None;
}
