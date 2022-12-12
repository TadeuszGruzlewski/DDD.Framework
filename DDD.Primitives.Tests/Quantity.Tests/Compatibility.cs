using NUnit.Framework;
using DDD.Primitives.Dimensions;
using DDD.Primitives.DimensionUoMs;

namespace QuantityTests;

public class Compatibility
{
    [Test]
    public void Compatible()
    {
        //Arrange
        Length l1 = new(LengthUoM.dm, 10);
        Length l2 = new(LengthUoM.m, 20);

        //Act
        bool b = l1.IsCompatibleWith(l2);

        //Assert
        Assert.IsTrue(b);
    }

    [Test]
    public void Incompatible()
    {
        //Arrange
        Length l = new(LengthUoM.dm, 10);
        Area a = new(AreaUoM.m2, 20);

        //Act
        bool b = l.IsCompatibleWith(a);

        //Assert
        Assert.IsFalse(b);
    }

    [Test]
    public void IncompatibleWithNull()
    {
        //Arrange
        Length l1 = new(LengthUoM.dm, 10);
        Length? l2 = null;

        //Act
        bool b = l1.IsCompatibleWith(l2);

        //Assert
        Assert.IsFalse(b);
    }
}
