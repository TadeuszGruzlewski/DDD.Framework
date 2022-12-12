//using DDD.Primitives.UoMs;

//namespace DDD.Primitives.LogisticUoMs;

//public record class BulkUoM : UoM
//{
//    public static readonly BulkUoM None = new(0, "None", 0);
//    public static readonly BulkUoM m3 = new(100, "cubic meter", 1);
////    public static readonly BulkUoM ft3 = new(500, "cubic foot", ft3, 1);

//    public static readonly BulkUoM l = new(200, "litre", l, 1);
//    public static readonly BulkUoM Hl = new(201, "hectolitre", l, 100);
//    //public static readonly BulkUoM USgal = new(600, "US gallon");
//    //public static readonly BulkUoM BIgal = new(601, "British Imperial gallon");

//    private BulkUoM(int id, string name, BulkUoM? _base, decimal rate) =>
//        (Id, Name, Base, Rate) = (id, name, _base, rate);
//}
