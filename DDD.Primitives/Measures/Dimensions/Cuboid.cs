using DDD.Foundations;

namespace DDD.Primitives.Dimensions;

// Unit of Measure by default in cm
// Should be extended to allow UoM either cm or inch
public record class Cuboid(int Length, int Width, int Height) : Primitive
{
    public static readonly Cuboid Minimum = new(0, 0, 0);

    public static bool operator <=(Cuboid s1, Cuboid s2) =>
        s1.Length <= s2.Length & s1.Width <= s2.Width & s1.Height <= s2.Height;
    public static bool operator >=(Cuboid s1, Cuboid s2) => !(s1 <= s2);

    public static bool operator <=(Cuboid s, decimal sum) =>
        s.Length + s.Width + s.Height <= sum;
    public static bool operator >=(Cuboid s, decimal sum) => !(s <= sum);

    public override bool IsValid()
    {
        bool valid = 0 <= Length & 0 <= Width & 0 <= Height;
        if (!valid)
            SetErrorMsg($"All dimensions of {GetType().Name} must not be negative.");
        return valid;
    }
}
