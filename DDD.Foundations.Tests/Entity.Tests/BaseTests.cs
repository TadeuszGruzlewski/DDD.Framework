using System;
using NUnit.Framework;

namespace EntityTests;

public class BaseTests
{
    [Test]
    public void CreateMyEntityWithNullId_ShouldFail()
    {
        //Arrange
        MyId? id = null;
        MyEntity<MyId> entity;

        //Act and Assert
        Assert.Throws<ArgumentNullException>(() => entity = new(id));
    }

    [Test]
    public void CreateMyEntity_CheckIdentity()
    {
        //Arrange
        MyId id;
        MyEntity<MyId> entity;

        //Act
        id = new(10);
        entity = new(id);

        //Assert
        Assert.IsTrue(entity.Id == id);
        Assert.IsTrue(id.Code == 10);
    }
}
