using DDD.Primitives.Dimensions;

namespace DDD.Examples.Baggage;

// Unit of Measure by default in cm
// Should be extended to allow UoM either cm or inch
public record class Size(int Length, int Width, int Height) : Cuboid(Length, Width, Height)
{
    public static bool operator <=(Size s, decimal sum) =>
        s.Length + s.Width + s.Height <= sum;
    public static bool operator >=(Size s, decimal sum) =>
        s.Length + s.Width + s.Height >= sum;
}
