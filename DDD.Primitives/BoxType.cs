using DDD.Foundations;
using DDD.Primitives.Dimensions;
using DDD.Primitives.DimensionUoMs;

// TODO is the right place and namespace
namespace DDD.Primitives.Boxes;

public record class BoxType : Enumeration
{
    public static readonly BoxType NoBox = new(0, "No Box", MakeDim(0, 0, 0));
    public static readonly BoxType Small = new(100, "Small Box", MakeDim(10, 20, 20));
    public static readonly BoxType Medium = new(200, "Medium Box", MakeDim(30, 30, 30));
    public static readonly BoxType Large = new(300, "Large Box", MakeDim(50, 100, 70));
    public static readonly BoxType Infinite = new(999, "Infinite Box", MakeDim(int.MaxValue, int.MaxValue, int.MaxValue)); 

    private static readonly LengthUoM uom = LengthUoM.cm;
    private static Box MakeDim(decimal h, decimal w, decimal l)
        => new (new Length(uom, h), new Length(uom, w), new Length(uom, l));

    private BoxType(int id, string name, Box dimensions) : base (id, name) => Dimensions = dimensions;

    public Box Dimensions { get; init; }

    public Volume Capacity => Dimensions.Capacity;

    public bool? CanContain(Box dimensions) => Dimensions.CanContain(dimensions);
    public bool? CanContain(Volume volume) => Dimensions.CanContain(volume);

    //public static BoxType GetBestBox(Volume volume)
    //{
    //    // TODO add UoM logic
    //    BoxType bestBox = Infinite;
    //    foreach (BoxType box in GetAll<BoxType>())
    //        if (bestBox.CanContain(box.Capacity) & box.CanContain(volume))
    //            bestBox = box;
    //    return bestBox == Infinite ? NoBox : bestBox;
    //}

    //public static BoxType GetBestBox(Box dimensions)
    //{
    //    // TODO add UoM logic
    //    BoxType bestBox = Infinite;
    //    foreach (BoxType box in GetAll<BoxType>())
    //        if (bestBox.CanContain(box.Dimensions) & box.CanContain(dimensions))
    //            bestBox = box;
    //    return bestBox == Infinite ? NoBox : bestBox;
    //}

    //public static readonly BoxUoM Large = new XBox();
    //private record class XBox() : BoxUoM(0, "No Box")
    //{
    //    protected override Dimensions getDimensions() => new(0, 0, 0);
    //}
}
