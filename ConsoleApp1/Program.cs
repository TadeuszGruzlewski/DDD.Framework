using DDD.Foundations;
using DDD.Primitives.Addresses;
using DDD.Primitives.DimensionUoMs;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

using Equality;

//public sealed record SimpleVo
//    : IEquatable<SimpleVo>
//{
//    //public bool Equals(SimpleVo other) =>
//    //    throw new System.NotImplementedException();

//    public override bool Equals(object? obj) =>
//        obj is SimpleVo other && Equals(other);

//    public override int GetHashCode() =>
//        throw new System.NotImplementedException();

//    public static bool operator ==(SimpleVo left, SimpleVo right) =>
//        left.Equals(right);

//    public static bool operator !=(SimpleVo left, SimpleVo right) =>
//        !left.Equals(right);
//}

var u1 = new User() { Name1 = "Ewa", Surname = "Szcz" };
var u2 = new User() { Name1 = "Ewa", Surname = "Gru" };
Console.WriteLine(u1 == u2);
Console.WriteLine();



//var address1 = new Address("1234 Main St", "20012");//, new[] { "" });// { "Comment1", "Comment2" });
//var address2 = new Address("1234 Main St", "20012");//, new[] { "" });// { "Comment1", "Comment2" });


//Console.WriteLine(address1 == address2);
//public record Address(string Street, string ZipCode);//, string[] Comments);


//var myId = new MyId(1);
//var MyEntityBuilder = new EntityBuilder<MyEntity, MyId>(myId);
//var y = MyEntityBuilder.Build();

//record MyId(int I) : EntityId
//{
//    public override bool IsValid() => true;
//}

//class MyEntity : Entity<MyId>
//{
//    public MyEntity() : base() { }

//    public MyEntity(MyId id) : base(id) { }
//}




//var c = new Country(-5, "");
//c.Validate();
//foreach(var e in c.Errors)
//    Console.WriteLine(e);

//Regex regex = new ("[0-9]{4}[A-Z]{2}$", RegexOptions.IgnoreCase);
//Console.WriteLine(regex.IsMatch("1234Ac"));

//A.test(out B k);
//Console.WriteLine(k.z);

//class A
//{
//    public static void test (out B b)
//    {
//        b = new B();
//        b.z = 55;
//    }
//}

//class B
//{
//    public int z;
//}
