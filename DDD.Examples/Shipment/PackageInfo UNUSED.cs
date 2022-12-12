//using DDD.Foundations;
//using DDD.Primitives.Dimensions;
//using DDD.Primitives.DimensionUoMs;

//namespace DDD.Examples.Shipment;

//public record class PackageInfo : ValueObject
//{
//    public PackageInfo(int l, int w, int h, LengthUoM unit) =>
//        Dimensions = new (new Length(unit, l), new Length(unit, w), new Length(unit, h));

//    public Box Dimensions { get; init; }


//    protected override bool AssertInvariants(List<InvariantError> errors)
//    {
//        throw new NotImplementedException();
//    }
//}
