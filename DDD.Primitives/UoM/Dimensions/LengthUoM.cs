using DDD.Primitives.UoMs;

namespace DDD.Primitives.DimensionUoMs;

public record class LengthUoM : UoM
{
    public static readonly LengthUoM None = new(0, "None", 0);
    public static readonly LengthUoM mm = new(1, "mm", 0.001m);
    public static readonly LengthUoM cm = new(2, "cm", 0.01m);
    public static readonly LengthUoM dm = new(3, "dm", 0.1m);
    public static readonly LengthUoM m = new(4, "m", 1);
    public static readonly LengthUoM km = new(5, "km", 1000);

    protected override UoM GetBase() => m;

    protected LengthUoM(int id, string name, decimal rate) : base(id, name, rate) {}
}
