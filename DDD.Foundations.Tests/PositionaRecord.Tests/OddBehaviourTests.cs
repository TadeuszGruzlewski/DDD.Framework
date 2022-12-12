using System;
using NUnit.Framework;

namespace PositionalRecordTests;

internal record Foo11(int Bar)
{
    public int Bar => 20;
    public int Baz = Bar;
    public int BaZ => Bar;
}

internal record Foo12(int Bar)
{
    public int Bar = Bar;
    public int Baz = Bar;
    public int BaZ => Bar;
}

#pragma warning disable CS8907 // Parameter is unread. Did you forget to use it to initialize the property with that name?
internal record Foo13(int Bar)
#pragma warning restore CS8907 // Parameter is unread. Did you forget to use it to initialize the property with that name?
{
    public int Bar => Bar; //infinite loop
}

public class OddBehaviourTests
{
    [Test]
    public void Odd11()
    {
        //Arrange
        Foo11 f;

        //Act
        f = new(10);

        //Assert
        Assert.AreEqual(f.Bar, 20);
        Assert.AreEqual(f.Baz, 10);
        Assert.AreEqual(f.BaZ, 20);
    }

    [Test]
    public void Odd12()
    {
        //Arrange
        Foo12 f;

        //Act
        f = new(10);

        //Assert
        Assert.AreEqual(f.Bar, 10);
        Assert.AreEqual(f.Baz, 10);
        Assert.AreEqual(f.BaZ, 10);
    }

    //// THIS IS A TEST FOR INFINITE LOOP <<<<<<<<<<<<<<<<<<<<<
    //// DO NOT REMOVE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    //// COMMENTED OUT BECAUSE IT CONFUSES OTHER TESTS <<<<<<<<
    //[Test]
    //public void Odd13()
    //{
    //    //Arrange
    //    Foo13 f;

    //    //Act
    //    f = new(10);

    //    //Assert
    //    // infinite loop
    //    Assert.AreEqual(f.Bar, 10);
    //}

}
