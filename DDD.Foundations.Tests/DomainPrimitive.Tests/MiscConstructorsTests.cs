using System;
using NUnit.Framework;

namespace DomainPrimitiveTests;

public class MiscConstructorTests
{
    internal record class KeyWithEmptyConstructorAndGoodValue(long Value) : Key(Value)
    {
        public KeyWithEmptyConstructorAndGoodValue() : this(100) { }
    }

    [Test]
    public void CreateKeyWithEmptyConstructorAndGoodValue_CatchArgumentException()
    {
        //Arrange
        KeyWithEmptyConstructorAndGoodValue k;

        //Act
        k = new();

        //Assert
        Assert.AreEqual(100, k.Value);
    }


    internal record class KeyWithEmptyConstructorAndBadValue(long Value) : Key(Value)
    {
        public KeyWithEmptyConstructorAndBadValue() : this(0) { }
    }

    [Test]
    public void CreateKeyWithEmptyConstructorAndBadValue_CatchArgumentException()
    {
        //Arrange
        KeyWithEmptyConstructorAndBadValue k;

        //Act and Assert
        Assert.Throws<ArgumentException>(() => k = new());
    }


    internal record class KeyWithDefaultNullConstructor(long Value) : Key(Value)
    {
        public KeyWithDefaultNullConstructor(KeyWithDefaultNullConstructor? id = null) : base(id!) { }
    }

    [Test]
    public void CreateKeyWithDefaultNullConstructor_CatchInvalidOperationException()
    {
        //Arrange
        KeyWithDefaultNullConstructor k;

        //Act and Assert
        Assert.Throws<InvalidOperationException>(() => k = new());
    }


    internal record class KeyDerivedFromGoodArgument() : Key(10)
    {
        public KeyDerivedFromGoodArgument(long v) : this() { Value = v; }
    }

    [Test]
    public void CreateKeyDerivedFromGoodArgument_CheckIfCorrect()
    {
        //Arrange
        KeyDerivedFromGoodArgument k;

        //Act
        k = new(1000);

        //Assert
        Assert.AreEqual(1000, k.Value);
    }
}
