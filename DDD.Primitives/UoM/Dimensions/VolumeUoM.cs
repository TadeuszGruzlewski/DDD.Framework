using DDD.Primitives.UoMs;

namespace DDD.Primitives.DimensionUoMs;

public record class VolumeUoM : UoM
{
    public static readonly VolumeUoM None = new(0, "None", 0);
    public static readonly VolumeUoM m3 = new(1, "Cubic meter", 1);

    protected override UoM GetBase() => m3;

    private VolumeUoM(int id, string name, decimal rate) : base(id, name, rate) { }
}
