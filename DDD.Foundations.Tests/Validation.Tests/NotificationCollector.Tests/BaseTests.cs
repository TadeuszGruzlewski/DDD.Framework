using DDD.Foundations;
using NUnit.Framework;

namespace NotificationCollectorTests;

public class BaseTests
{
    [Test]
    public void ContextTest()
    {
        //Arrange
        NotificationCollector c = new();

        //Act
        c.ExtendContext("A");
        c.ExtendContext("B");
        c.ExtendContext("C");
        c.ExtendContext("D");
        c.ReduceContext();
        c.ReduceContext();

        //Assert
        Assert.AreEqual(c.Context, "A >>> B");
    }
}
