using System;
using DDD.Foundations;
using NUnit.Framework;

namespace EnumerationTests;

internal record class ExtendedStateEnum : StateEnum
{
    public static readonly ExtendedStateEnum Cancelled = new(3, "Cancelled");
    public static readonly ExtendedStateEnum Failed = new(4, "Failed");

    public ExtendedStateEnum(int id, string name) : base(id, name) { }

   public override ExtendedStateEnum Downcast(Enumeration s) => new (s.Id, s.Name);

    // user defined conversion to or from base type are not allowed
    //public static implicit operator ExtendedStateEnum(Enumeration enumeration) => new (enumeration.Id, enumeration.Name);
}

public class InheritanceTests
{
    [Test]
    public void Expected0()
    {
        //Assert
        Assert.AreEqual(StateEnum.NotStarted.Id, 0);
        Assert.AreEqual(StateEnum.NotStarted.Name, "Not Started");
    }

    [Test]
    public void Expected3()
    {
        //Assert
        Assert.AreEqual(ExtendedStateEnum.Cancelled.Id, 3);
        Assert.AreEqual(ExtendedStateEnum.Cancelled.Name, "Cancelled");
    }

    [Test]
    public void Expected4()
    {
        //Assert
        Assert.AreEqual(ExtendedStateEnum.Failed.Id, 4);
        Assert.AreEqual(ExtendedStateEnum.Failed.Name, "Failed");
    }

    [Test]
    public void Enumerator2Levels()
    {
        //Arrange
        var all = Enumeration.GetAll<ExtendedStateEnum>();
        var visited = new bool[6];

        //Act 
        foreach (var item in all)
            visited[item.Id] = true;

        //Assert
//            Assert.IsTrue(visited[0] & visited[1] & visited[2]);
        Assert.IsTrue(visited[3] & visited[4]);
    }

    [Test]
    public void Enumerator3Levels()
    {
        //Arrange
        var all = Enumeration.GetAll<StateEnum>();
        var visited = new bool[6];

        //Act 
        foreach (var item in all)
            visited[item.Id] = true;

        //Assert
        //            Assert.IsTrue(visited[0] & visited[1] & visited[2]);
        Assert.IsTrue(visited[3] & visited[4]);
    }

}
