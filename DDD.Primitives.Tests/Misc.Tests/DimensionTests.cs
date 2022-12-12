//using DDD.Primitives.Dimension;
//using DDD.Primitives.DimensionUoMs;
//using NUnit.Framework;
//using System;

//namespace MiscTests;

//public class DimensionTests
//{
//    [Test]
//    public void SubWrong()
//    {
//        //Arrange
//        Length l;
//        Dimensions d, d1, d2;

//        //Act
//        l = new(LengthUoM.cm, 5);
//        d1 = new(l, l, l);
//        d2 = new(l, l, l);

//        //Assert
//        Assert.Throws<ArgumentException>(() => d = d1 - d2);
//    }

//}
