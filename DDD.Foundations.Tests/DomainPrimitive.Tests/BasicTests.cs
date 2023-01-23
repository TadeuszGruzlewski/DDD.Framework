using System;
using NUnit.Framework;
using DDD.Foundations;

namespace DomainPrimitiveTests;

internal record class Key(long Value) : Primitive
{
    public override bool IsValid()
    {
        var valid = Value > 0;
        if (!valid)
            SetErrorMsg($"{GetType().Name}.Value must be a positive number.");
        return valid;
    }
}

public class BasicTests
{
    [Test]
    public void CreateKeyWithGoodValue_CheckIfCorrect()
    {
        //Arrange
        Key k;

        //Act
        k = new(100);

        //Assert
        Assert.AreEqual(100, k.Value);
    }

    [Test]
    public void CreateKeyWithZeroValue_CatchArgumentException()
    {
        //Arrange
        Key k;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => k = new(0));
    }

    [Test]
    public void CreateKeyWithNegativeValue_CatchArgumentException()
    {
        //Arrange
        Key k;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => k = new(-1));
    }

}
