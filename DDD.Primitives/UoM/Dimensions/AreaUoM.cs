using DDD.Primitives.UoMs;

namespace DDD.Primitives.DimensionUoMs;

public record class AreaUoM : UoM
{
    public static readonly AreaUoM None = new(0, "None", 0);
    public static readonly AreaUoM m2 = new(1, "square meter", 1);
    public static readonly AreaUoM ha = new(2, "hectare", 10000);

    protected override UoM GetBase() => m2;

    private AreaUoM(int id, string name, decimal rate) : base(id, name, rate) { }
}
