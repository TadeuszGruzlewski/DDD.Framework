using System;
using DDD.Foundations;
using NUnit.Framework;

namespace EntityTests;

public class EqualityTestsByEquals
{
    [Test]
    public void NullReferenceToSecondEntity_EqualsIsFalse()
    {
        //Arrange
        MyId id;
        MyEntity<MyId>? entity1, entity2;

        //Act
        id = new(10);
        entity1 = new(id, 1);
        entity2 = null;

        //Assert
        Assert.IsFalse(entity1.Equals(entity2));
    }

    [Test]
    public void EntitiesWithSameReferencest_EqualsIsTrue()
    {
        //Arrange
        MyId id;
        MyEntity<MyId> entity1, entity2;

        //Act
        id = new(10);
        entity1 = new(id, 1);
        entity2 = entity1;

        //Assert
        Assert.IsTrue(entity1.Equals(entity2));
    }

    [Test]
    public void EntitiesWithSameIdAndDifferentContent_EqualsIsTrue()
    {
        //Arrange
        MyId id;
        MyEntity<MyId> entity1, entity2;

        //Act
        id = new(10);
        entity1 = new(id, 1);
        entity2 = new(id, 100);

        //Assert
        Assert.IsTrue(entity1.Equals(entity2));
    }

    [Test]
    public void EntitiesWithDifferentIdsAndSameContent_EqualsIsFalse()
    {
        //Arrange
        MyId id1, id2;
        MyEntity<MyId> entity1, entity2;

        //Act
        id1 = new(10);
        id2 = new(20);
        entity1 = new(id1, 100);
        entity2 = new(id2, 100);

        //Assert
        Assert.IsFalse(entity1.Equals(entity2));
    }

    [Test]
    public void EntitiesOfDifferentType_EqualsIsFalse()
    {
        //Arrange
        MyId id;
        MyId1 id1;
        Entity entity1, entity2;

        //Act
        id = new(10);
        id1 = new(10);
        entity1 = new MyEntity<MyId>(id, 1);
        entity2 = new MyEntity1<MyId1>(id1, 1);

        //Assert
        Assert.IsFalse(entity1.Equals(entity2));
    }

}