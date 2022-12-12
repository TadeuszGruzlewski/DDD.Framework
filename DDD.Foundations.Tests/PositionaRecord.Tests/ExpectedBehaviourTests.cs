using System;
using NUnit.Framework;

namespace PositionalRecordTests;

internal record Foo(int Bar);

internal record Foo1(int Bar)
{
    public int Bar = Bar;
}

#pragma warning disable CS8907 // Parameter is unread. Did you forget to use it to initialize the property with that name?
internal record Foo2(int Bar)
#pragma warning restore CS8907 // Parameter is unread. Did you forget to use it to initialize the property with that name?
{
    public int Bar { get; }
}

internal record Foo3(int Bar)
{
    public int Baz = Bar;
    public int BaZ => Bar;
}

public class ExpectedBehaviourTests
{
    [Test]
    public void Expected()
    {
        //Arrange
        Foo f;

        //Act
        f = new(10);

        //Assert
        Assert.AreEqual(f.Bar, 10);
    }

    [Test]
    public void Expected1()
    {
        //Arrange
        Foo1 f;

        //Act
        f = new(10);

        //Assert
        Assert.AreEqual(f.Bar, 10);
    }

    [Test]
    public void Expected2()
    {
        //Arrange
        Foo2 f;

        //Act
        f = new(10);

        //Assert
        Assert.AreEqual(f.Bar, 0);
    }

    [Test]
    public void Expected3()
    {
        //Arrange
        Foo3 f;

        //Act
        f = new(10);

        //Assert
        Assert.AreEqual(f.Bar, 10);
        Assert.AreEqual(f.Baz, 10);
        Assert.AreEqual(f.BaZ, 10);
    }
}
