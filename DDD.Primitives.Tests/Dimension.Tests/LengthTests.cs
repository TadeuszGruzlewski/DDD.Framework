using DDD.Primitives.Dimensions;
using DDD.Primitives.DimensionUoMs;
using NUnit.Framework;
using System;

namespace DimensionTests;

public class LengthTests
{
    [Test]
    public void NormalizeTest()
    {
        //Arrange
        Length l = new(LengthUoM.dm, 5);

        //Act
        var n = l.Normalize();

        //Assert
        Assert.AreEqual(n.UoM, LengthUoM.m);
        Assert.AreEqual(n.Amount, 0.5);
    }

    [Test]
    public void Convert_Incompatible()
    {
        //Arrange
        Length l = new(LengthUoM.m, 10);
        Area a;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => a = (Area)l.ConvertTo(AreaUoM.m2));
    }

    [Test]
    public void ConvertTest0()
    {
        //Arrange
        Length l = new(LengthUoM.m, 10);

        //Act
        var n = l.ConvertTo(LengthUoM.m);

        //Assert
        Assert.AreEqual(n.UoM, LengthUoM.m);
        Assert.AreEqual(n.Amount, 10);
    }

    [Test]
    public void ConvertTest1()
    {
        //Arrange
        Length l = new(LengthUoM.dm, 5);

        //Act
        var n = l.ConvertTo(LengthUoM.cm);

        //Assert
        Assert.AreEqual(n.UoM, LengthUoM.cm);
        Assert.AreEqual(n.Amount, 50);
    }

    [Test]
    public void ConvertTest2()
    {
        //Arrange
        Length l = new(LengthUoM.m, 10);

        //Act
        var n = l.ConvertTo(LengthUoM.km);

        //Assert
        Assert.AreEqual(n.UoM, LengthUoM.km);
        Assert.AreEqual(n.Amount, 0.01);
    }

    [Test]
    public void ConvertTest3()
    {
        //Arrange
        Length l = new(LengthUoM.m, 10);

        //Act
        var n = l.ConvertTo(LengthUoM.mm);

        //Assert
        Assert.AreEqual(n.UoM, LengthUoM.mm);
        Assert.AreEqual(n.Amount, 10000);
    }

    [Test]
    public void ConvertTest4()
    {
        //Arrange
        Length l = new(LengthUoM.km, 0.2m);

        //Act
        var n = l.ConvertTo(LengthUoM.dm);

        //Assert
        Assert.AreEqual(n.UoM, LengthUoM.dm);
        Assert.AreEqual(n.Amount, 2000);
    }

    [Test]
    public void ConvertTest5()
    {
        //Arrange
        Length l = new(LengthUoM.km, 0.2m);
        Length l1;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => l1 = (Length)l.ConvertTo(AreaUoM.ha));
    }

}
