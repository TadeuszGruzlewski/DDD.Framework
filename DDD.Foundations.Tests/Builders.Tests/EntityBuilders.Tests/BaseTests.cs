using System;
using DDD.Foundations;
using EntityTests;
using NUnit.Framework;

namespace EntityBuildersTests;

public class BaseTests
{
    [Test]
    public void BuildMyEntityWithNullId_ShouldFail()
    {
        //Arrange
        MyEntity entity;
        MyBuilder b;

        //Act and Assert
        Assert.Throws<ArgumentNullException>(() => entity = new(null), "");
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
        myEntity = b.Build();

        //Assert
        Assert.IsTrue(myEntity?.Id == id);
        Assert.IsTrue(id.Code == 10);
    }
}
