using NUnit.Framework;
using System;
using DDD.Primitives.Dimensions;
using DDD.Primitives.DimensionUoMs;

namespace QuantityTests;

public class LessOverloading
{
    [Test]
    public void NullBoth()
    {
        //Arrange
        Length? q1 = null;
        Length? q2 = null;

        //Act
        var q = q1 < q2;

        //Assert
        Assert.AreEqual(q, null);
    }

    [Test]
    public void NullFirst()
    {
        //Arrange
        Length q2 = new(LengthUoM.m, 20);

        //Act
        var q = null < q2;

        //Assert
        Assert.AreEqual(q, null);
    }

    [Test]
    public void NullLast()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 0);

        //Act
        var q = q1 < null;

        //Assert
        Assert.AreEqual(q, null);
    }

    [Test]
    public void ZeroBoth()
    {
        //Arrange
        Length q1 = Length.Zero;
        Length q2 = Length.Zero;

        //Act
        var q = q1 <= q2;

        //Assert
        Assert.IsTrue(q);
    }

    [Test]
    public void ZeroFirst()
    {
        //Arrange
        Length q2 = new(LengthUoM.m, 20);

        //Act
        var q = Length.Zero < q2;

        //Assert
        Assert.IsTrue(q);
    }

    [Test]
    public void ZeroLast()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 0);

        //Act
        var q = q1 <= Length.Zero;

        //Assert
        Assert.IsTrue(q);
    }

    [Test]
    public void Less_SameUoM()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 10);
        Length q2 = new(LengthUoM.m, 10);

        //Act
        var q = q1 <= q2;

        //Assert
        Assert.IsTrue(q);
    }

    [Test]
    public void Less_CompatibleUoM()
    {
        //Arrange
        Length q1 = new(LengthUoM.m, 10);
        Length q2 = new(LengthUoM.dm, 200);

        //Act
        bool? q = q1 < q2;

        //Assert
        Assert.IsFalse(q);
    }

    [Test]
    public void Less_IncompatibleUoM()
    {
        //Arrange
        bool? q;
        Length q1 = new(LengthUoM.m, 10);
        Area q2 = new(AreaUoM.m2, 20);

        //Act and Assert
        Assert.Throws<ArgumentException>(() => q = q1 < q2);
    }
}
