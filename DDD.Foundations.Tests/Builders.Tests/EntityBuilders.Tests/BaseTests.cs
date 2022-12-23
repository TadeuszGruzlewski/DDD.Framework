using System;
using NUnit.Framework;

namespace EntityBuildersTests;

public class BaseTests
{
    [Test]
    public void BuildMyEntityWithNullId_ShouldFail()
    {
        //Arrange
        MyBuilder b;

        //Act and Assert
        Assert.Throws<ArgumentNullException>(() => b = new(null));
    }

    [Test]
    public void BuildMyEntity_CheckIdentity()
    {
        //Arrange
        MyId id;
        MyEntity<MyId>? myEntity;
        MyBuilder b;

        //Act
        id = new(10);
        b = new(id);
        myEntity = b.Build(nameof(myEntity));

        //Assert
        Assert.IsTrue(myEntity?.Id == id);
        Assert.IsTrue(id.Code == 10);
    }
}
