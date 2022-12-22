using System;
using DDD.Foundations;
using NUnit.Framework;

namespace NotificationCollectorTests;

public class BaseTests
{
    [Test]
    public void CreateMyEntityWithNullId_ShouldFail()
    {
        //Arrange
        NotificationCollector c = new();

        //Act
        c.ExtendContext("A");
        c.ExtendContext("B");
        c.ExtendContext("C");
        c.ReduceContext();

        //Assert
        Assert.AreEqual(c.Context, "A >>> B");
    }
}
