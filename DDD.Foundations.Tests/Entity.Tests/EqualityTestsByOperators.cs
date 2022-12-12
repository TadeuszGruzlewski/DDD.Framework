using System;
using NUnit.Framework;

namespace EntityTests;

public class EqualityTestsByOperators
{
    [Test]
    public void EntitiesWithSameReferences_EqualityOperatorIsTrue()
    {
        //Arrange
        MyId id;
        MyEntity<MyId> entity1, entity2;

        //Act
        id = new(10);
        entity1 = new(id, 1);
        entity2 = entity1;

        //Assert
        Assert.IsTrue(entity1 == entity2);
    }

    [Test]
    public void EntitiesWithSameIdAndDifferentContent_EqualityOperatorIsTrue()
    {
        //Arrange
        MyId id;
        MyEntity<MyId> entity1, entity2;

        //Act
        id = new(10);
        entity1 = new(id, 1);
        entity2 = new(id, 100);

        //Assert
        Assert.IsTrue(entity1 == entity2);
    }

    [Test]
    public void EntitiesWithDifferentIdsAndSameContent_InequalityOperatorIsTrue()
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
        Assert.IsTrue(entity1 != entity2);
    }
}