using DDD.Foundations;
using NUnit.Framework;

namespace EnumerationTests;

public record class StateEnum : Enumeration
{
    public static readonly StateEnum NotStarted = new(0, "Not Started");
    public static readonly StateEnum InProgress = new(1, "In Progress");
    public static readonly StateEnum Finished = new(2, "Finished");

    protected StateEnum(int id, string name) : base(id, name) { }
}

public class BasicTests
{
    [Test]
    public void Expected0()
    {
        //Assert
        Assert.AreEqual(StateEnum.NotStarted.Id, 0);
        Assert.AreEqual(StateEnum.NotStarted.Name, "Not Started");
    }

    [Test]
    public void Expected1()
    {
        //Assert
        Assert.AreEqual(StateEnum.InProgress.Id, 1);
        Assert.AreEqual(StateEnum.InProgress.Name, "In Progress");
    }

    [Test]
    public void Expected2()
    {           
        //Assert
        Assert.AreEqual(StateEnum.Finished.Id, 2);
        Assert.AreEqual(StateEnum.Finished.Name, "Finished");
    }

    [Test]
    public void AreEqual()
    {
        //Assert
#pragma warning disable CS1718 // Comparison made to same variable
        Assert.IsTrue(StateEnum.Finished == StateEnum.Finished);
#pragma warning restore CS1718 // Comparison made to same variable
    }

    [Test]
    public void AreNotEqual()
    {
        //Assert
        Assert.IsTrue(StateEnum.Finished != StateEnum.NotStarted);
    }

    [Test]
    public void Enumerator()
    {
        //Arrange
        var all = Enumeration.GetAll<StateEnum>();
        var visited = new bool[3];

        //Act 
        foreach (var item in all)
            visited[item.Id] = true;

        //Assert
        Assert.IsTrue(visited[0] & visited[1] & visited[2]);
    }
}
