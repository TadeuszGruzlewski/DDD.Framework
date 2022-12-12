using NUnit.Framework;
using DDD.Primitives.Dimensions;
using DDD.Primitives.DimensionUoMs;

namespace QuantityTests;

public class Conversions
{
    [Test]
    public void ConversionUp()
    {
        //Arrange
        Length l1 = new(LengthUoM.dm, 100);

        //Act
        Length l2 = (Length)l1.ConvertTo(LengthUoM.m);

        //Assert
        Assert.AreEqual(LengthUoM.m, l2.UoM);
        Assert.AreEqual(10, l2.Amount);
    }

    [Test]
    public void ConversionDown()
    {
        //Arrange
        Length l1 = new(LengthUoM.dm, 10);

        //Act
        Length l2 = (Length)l1.ConvertTo(LengthUoM.cm);

        //Assert
        Assert.AreEqual(LengthUoM.cm, l2.UoM);
        Assert.AreEqual(100, l2.Amount);
    }

    [Test]
    public void ConversionSame()
    {
        //Arrange
        Length l1 = new(LengthUoM.dm, 10);

        //Act
        Length l2 = (Length)l1.ConvertTo(LengthUoM.dm);

        //Assert
        Assert.AreEqual(LengthUoM.dm, l2.UoM);
        Assert.AreEqual(10, l2.Amount);
    }

    [Test]
    public void GetRateUp()
    {
        //Arrange
        Length l1 = new(LengthUoM.dm, 100);
        Length l2 = new(LengthUoM.m, 20);

        //Act
        decimal r = l1.GetRateTo(l2);

        //Assert
        Assert.AreEqual(0.5m, r);
    }

    [Test]
    public void GetRateDown()
    {
        //Arrange
        Length l1 = new(LengthUoM.dm, 100);
        Length l2 = new(LengthUoM.m, 20);

        //Act
        decimal r = l2.GetRateTo(l1);

        //Assert
        Assert.AreEqual(2, r);
    }

    [Test]
    public void GetRateSame()
    {
        //Arrange
        Length l1 = new(LengthUoM.dm, 20);
        Length l2 = new(LengthUoM.dm, 20);

        //Act
        decimal r = l1.GetRateTo(l2);

        //Assert
        Assert.AreEqual(1, r);
    }
}
