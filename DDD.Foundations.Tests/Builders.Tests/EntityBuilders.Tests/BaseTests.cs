using System;
using NUnit.Framework;

namespace EntityBuildersTests;

public class BaseTests
{
    //[Test]
    //public void CreateMyEntityWithNullId_ShouldFail()
    //{
    //    //Arrange
    //    MyId? id = null;
    //    MyEntity<MyId> entity;

    //    //Act and Assert
    //    Assert.Throws<ArgumentNullException>(() => entity = new(id));
    //}

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
