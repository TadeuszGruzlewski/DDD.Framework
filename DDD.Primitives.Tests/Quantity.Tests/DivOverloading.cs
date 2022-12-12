using System;
using NUnit.Framework;
using DDD.Primitives.Dimensions;
using DDD.Primitives.DimensionUoMs;

namespace QuantityTests;

public class DivOverloading
{
    [Test]
    public void NullBoth()
    {
        //Arrange
        decimal? d;
        Length? q1 = null;
        Length? q2 = null;

        //Act
        d = q1 / q2;

        //Act and Assert
        Assert.AreEqual(d, null);
    }

    [Test]
    public void NullFirst()
    {
        //Arrange
        decimal? d;
        Length? q1 = null;
        Length q2 = Length.Zero;

        //Act
        d = q1 / q2;

        //Act and Assert
        Assert.AreEqual(d, null);
    }

    [Test]
    public void NullLast()
    {
        //Arrange
        decimal? d;
        Length q1 = Length.Zero;
        Length? q2 = null;

        //Act
        d = q1 / q2;

        //Act and Assert
        Assert.AreEqual(d, null);
    }

    [Test]
    public void ZeroBoth()
    {
        //Arrange
        decimal? d;

        //Act and Assert
        Assert.Throws<DivideByZeroException>(() => d = Length.Zero / Length.Zero);
    }

    [Test]
    public void ZeroFirst()
    {
        //Arrange
        Length l = new(LengthUoM.m, 20);

        //Act
        var d = Length.Zero / l;

        //Assert
        Assert.AreEqual(0, d);
    }

    [Test]
    public void ZeroLast()
    {
        //Arrange
        Length l = new(LengthUoM.m, 20);
        decimal? d;

        //Act and Assert
        Assert.Throws<DivideByZeroException>(() => d = l / Length.Zero);
    }

    [Test]
    public void Div_SameUoM()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 10);
        Length q2 = new(LengthUoM.m, 4);

        //Act
        var q = q1 / q2;

        //Assert
        Assert.AreEqual(q, 2.5m);
    }

    [Test]
    public void Div_Compatible()
    {
        //Arrange
        Length q1 = new(LengthUoM.dm, 10);
        Length q2 = new(LengthUoM.m, 2);

        //Act
        var q = q1 / q2;

        //Assert
        Assert.AreEqual(q, 0.5m);
    }

    [Test]
    public void Div_Incompatible()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 10);
        Area q2 = new(AreaUoM.m2, 20);
        decimal? d;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => d = q1 / q2);
    }

}
