using DDD.Primitives.Quantities;
using DDD.Primitives.Dimensions;
using NUnit.Framework;
using System;
using DDD.Primitives.DimensionUoMs;

namespace QuantityTests;

public class AddOverloading
{
    [Test]
    public void NullBoth()
    {
        //Arrange
        Length? q1 = null;
        Length? q2 = null;

        //and Act
        var q = q1 + q2;

        //Assert
        Assert.AreEqual(q, null);
    }

    [Test]
    public void NullFirst()
    {
        //Arrange
        Length? q1 = null;
        Length q2 = new(LengthUoM.m, 20);

        //Act
        var q = q1 + q2;

        //Assert
        Assert.AreEqual(q, null);
    }

    [Test]
    public void NullSecond()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 20);
        Length? q2 = null;

        //Act
        var q = q1 + q2;

        //Assert
        Assert.AreEqual(q, null);
    }

    public void ZeroBoth()
    {
        //Arrange and Act
        var q = Length.Zero + Length.Zero;

        //Assert
        Assert.AreEqual(q, Length.Zero);
    }

    [Test]
    public void ZeroFirst()
    {
        //Arrange
        Length q2 = new(LengthUoM.m, 20);

        //Act
        var q = Length.Zero + q2;

        //Assert
        Assert.AreEqual(q, q2);
    }

    [Test]
    public void ZeroLast()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 20);

        //Act
        var q = q1 + Length.Zero;

        //Assert
        Assert.AreEqual(q, q1);
    }

    [Test]
    public void Sum_SameUoM()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 10);
        Length q2 = new(LengthUoM.m, 20);

        //Act
        var q = q1 + q2;

        //Assert
        Assert.AreEqual(q?.UoM, LengthUoM.m);
        Assert.AreEqual(q?.Amount, 30);
    }

    [Test]
    public void Sum_Compatible()
    {
        //Arrange
        Length q1 = new(LengthUoM.dm, 10);
        Length q2 = new(LengthUoM.m, 20);

        //Act
        var q = q1 + q2;

        //Assert
        Assert.AreEqual(q?.UoM, LengthUoM.dm);
        Assert.AreEqual(q?.Amount, 210);
    }

    [Test]
    public void Sum_Incompatible()
    {
        //Arrange
        Quantity? q;
        Length q1 = new(LengthUoM.m, 10);
        Area q2 = new(AreaUoM.m2, 20);

        //Act and Assert
        Assert.Throws<ArgumentException>(() => q = q1 + q2);
    }

    [Test]
    public void Sub_SameUoM()
    {
        //Arrange
        Quantity? q;
        Length q1 = new(LengthUoM.m, 10);
        Length q2 = new(LengthUoM.m, 20);

        //Act and Assert
        Assert.Throws<ArgumentException>(() => q = q1 - q2);
    }

}
