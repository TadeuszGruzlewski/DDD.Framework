using System;
using NUnit.Framework;

namespace DomainPrimitiveTests;

public class IsValidRequiredTests
{
    internal record class KeyDerivedFromGoodArgument(): Key(10)
    {
        public KeyDerivedFromGoodArgument(long v) : this() { Value = v; }
    }

    [Test]
    public void CreateKeyDerivedFromGoodArgument_CheckIfCorrect()
    {
        //Arrange
        KeyDerivedFromGoodArgument k;

        //Act
        k = new(0);

        //Assert
        //Assert.AreEqual(0, k.Value);
        Assert.IsFalse(k.IsValid());
    }

    internal record class KeyWithDefaultGoodArgument(long Value = 100) : Key(Value);

    [Test]
    public void CreateKeyWithDefaultGoodArgumentAndWrongAssignment_CheckIfCorrect()
    {
        //Arrange
        KeyWithDefaultGoodArgument k;

        //Act
        k = new() { Value = 0 };

        //Assert
        //Assert.AreEqual(0, k.Value);
        Assert.IsFalse(k.IsValid());
    }
}
