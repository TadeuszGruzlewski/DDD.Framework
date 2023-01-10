using DDD.Foundations;
using DDD.Primitives.DimensionUoMs;

namespace DDD.Primitives.Dimensions;

public record class Box(Length H, Length L, Length W) : Primitive
{
    public override bool IsValid()
    {
        bool valid = H.Amount > 0 & L.Amount > 0 & W.Amount > 0;
        if (!valid)
            throw new ArgumentException($"{GetType().Name}.Dimensions must be positive numbers.");
        return valid;
    }

    // TODO add a unit of a single dimension (m, cm, inch, etc.)

    // TODO add UoM
    public Volume Capacity => new(VolumeUoM.None, 0); //new (VolumeUoM.None, H * L * W);

    // TODO add clearance, add UoM logic
    public bool? CanContain(Box d) => H < d.H & L < d.L & W < d.W;
    // TODO add margin
    public bool? CanContain(Volume volume) => volume <= Capacity;

    //public static Dimensions operator +(Dimensions q1, Dimensions q2) => new(q1.H + q2.H, q1.L + q2.L, q1.W + q2.W);
    //public static Dimensions operator -(Dimensions q1, Dimensions q2) => new(q1.H - q2.H, q1.L - q2.L, q1.W - q2.W);

    public static decimal? operator /(Box q1, Box q2) => (q1.H/q2.H) * (q1.L/q2.L) * (q1.W/q2.W);
    public static Box operator *(decimal factor, Box d)
    {
        throw new NotImplementedException();
        //if (factor <= 0)
        //    throw new ArgumentException("Factor must be positive");
        //return new(factor * d.H, factor * d.L, factor * d.W);
    }
}
