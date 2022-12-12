using System;
using NUnit.Framework;

namespace DomainPrimitiveTests;

public class CopyConstructorsTests
{
    internal record class KeyWithCopyConstructor(long Value) : Key(Value)
    {
        public KeyWithCopyConstructor(KeyWithCopyConstructor? id) : base(id!) { }
    }

    [Test]
    public void CreateKeyWithCopyConstructor_CopyUsingCopyConstructorWithNull_CatchInvalidOperationException()
    {
        //Arrange
        KeyWithCopyConstructor k;

        //Act and Assert
        Assert.Throws<InvalidOperationException>(() => k = new(null));
    }

    [Test]
    public void CreateKeyWithCopyConstructor_CopyUsingCopyConstructor_CatchInvalidOperationException()
    {
        //Arrange
        KeyWithCopyConstructor k;
        KeyWithCopyConstructor k1;

        //Act
        k = new(10);

        //Assert
        Assert.Throws<InvalidOperationException>(() => k1 = new(k));
    }

    [Test]
    public void CreateKey_CopyEmptyWith_CatchInvalidOperationException()
    {
        //Arrange
        Key k;
        Key k1;

        //Act
        k = new(10);

        //Assert
        Assert.Throws<InvalidOperationException>(() => k1 = k with {});
    }

    [Test]
    public void CreateKey_CopyNonEmptyWith_CatchInvalidOperationException()
    {
        //Arrange
        Key k;
        Key k1;

        //Act
        k = new(10);

        //Assert
        Assert.Throws<InvalidOperationException>(() => k1 = k with { Value = 5 });
    }
}
