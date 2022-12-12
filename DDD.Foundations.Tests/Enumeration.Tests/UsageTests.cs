using System;
using NUnit.Framework;

namespace EnumerationTests;

internal record class EmbeddingRecord(string Name, StateEnum Id)
{
    //public string GetName()
    //{
    //    switch (Id)
    //    {
    //        case MyEnum m when this.Id = MyEnum.NotStarted: break;
    //        case false: break;
    //    }
    //}
}

public class UsageTests
{
    [Test]
    public void TODO____EmbeddingRecordsEqual()
    {
        //Arrange
        EmbeddingRecord t1;
        EmbeddingRecord t2;

        //Act
        t1 = new("aaa", StateEnum.NotStarted);
        t2 = new("aaa", StateEnum.NotStarted);

        //Assert
        Assert.AreEqual(t1, t2);
    }

    [Test]
    public void TODO____EmbeddingRecordsNotEqual()
    {
        //Arrange
        EmbeddingRecord t1;
        EmbeddingRecord t2;

        //Act
        t1 = new("aaa", StateEnum.NotStarted);
        t2 = new("aaa", StateEnum.InProgress);

        //Assert
        Assert.AreNotEqual(t1, t2);
    }

}
