using System;
using DDD.Primitives.DimensionUoMs;
using DDD.Primitives.UoMs;
using NUnit.Framework;

namespace UoMTests;

public class BaseTests
{
    [Test]
    public void Compatible()
    {
        //Arrange
        LengthUoM l1 = LengthUoM.m;
        LengthUoM l2 = LengthUoM.dm;

        //Act
        bool b = l1.IsCompatibleWith(l2);

        //Assert
        Assert.IsTrue(b);
    }

    [Test]
    public void Incompatible()
    {
        //Arrange
        LengthUoM l = LengthUoM.m;
        AreaUoM a = AreaUoM.m2;

        //Act
        bool b = l.IsCompatibleWith(a);

        //Assert
        Assert.IsFalse(b);
    }
    [Test]
    public void IncompatibleWithNull()
    {
        //Arrange
        LengthUoM l = LengthUoM.m;
        LengthUoM? a = null;

        //Act
        bool b = l.IsCompatibleWith(a);

        //Assert
        Assert.IsFalse(b);
    }

    [Test]
    public void TestCompatibility()
    {
        //Arrange
        LengthUoM l = LengthUoM.m;
        AreaUoM a = AreaUoM.m2;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => l.TestCompatibilityTo(a));
    }

    [Test]
    public void TestCompatibilityToNull()
    {
        //Arrange
        LengthUoM l = LengthUoM.m;
        LengthUoM? a = null;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => l.TestCompatibilityTo(a));
    }

    [Test]
    public void GetRateTo_dm2cm()
    {
        //Arrange
        LengthUoM l1 = LengthUoM.cm;
        LengthUoM l2 = LengthUoM.dm;

        //Act
        decimal r = l2.GetRateTo(l1);

        //Assert
        Assert.AreEqual(10, r);
    }

    [Test]
    public void GetRateTo_cm2dm()
    {
        //Arrange
        LengthUoM l1 = LengthUoM.cm;
        LengthUoM l2 = LengthUoM.dm;

        //Act
        decimal r = l1.GetRateTo(l2);

        //Assert
        Assert.AreEqual(0.1m, r);
    }


    [Test]
    public void GetRateTo_Incompatible()
    {
        //Arrange
        LengthUoM l = LengthUoM.cm;
        AreaUoM a = AreaUoM.m2;
        decimal d;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => d = l.GetRateTo(a));
    }

}
