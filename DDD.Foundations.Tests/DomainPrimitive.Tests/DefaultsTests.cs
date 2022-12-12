using System;
using NUnit.Framework;

namespace DomainPrimitiveTests;

public class DefaultsTests
{
    internal record class KeyWithDefaultGoodArgument(long Value = 100) : Key(Value);

    internal record class KeyWithDefaultWrongArgument(long Value = 0) : Key(Value);

    [Test]
    public void CreateKeyWithDefaultGoodArgument_CheckIfCorrect()
    {
        //Arrange
        KeyWithDefaultGoodArgument k;

        //Act
        k = new();

        //Assert
        Assert.AreEqual(100, k.Value);
    }

    [Test]
    public void CreateKeyWithDefaultWrongArgument_CatchArgumentException()
    {
        //Arrange
        KeyWithDefaultWrongArgument k;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => k = new());
    }

    [Test]
    public void CreateKeyWithDefaultGoodArgumentAndGoodAssignment_CheckIfCorrect()
    {
        //Arrange
        KeyWithDefaultGoodArgument k;

        //Act
        k = new() { Value = 200 };

        //Assert
        Assert.AreEqual(200, k.Value);
    }

    [Test]
    public void CreateKeyWithDefaultWrongArgumentAndGoodAssignment_CatchArgumentException()
    {
        //Arrange
        KeyWithDefaultWrongArgument k;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => k = new() { Value = 100 });
    }
}
