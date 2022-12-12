using System;
using NUnit.Framework;

namespace EntityTests;

public class EqualityOperatorForLiftedTypes
{
    [Test]
    public void FirstNull_EqualOperator_ResultFalse()
    {
        //Arrange
        MyId id;
        MyEntity<MyId>? entity1, entity2;

        //Act
        id = new(10);
        entity1 = null;
        entity2 = new(id, 1);

        //Assert
        Assert.IsFalse(entity1 == entity2);
    }

    [Test]
    public void SecondNull_EqualOperator_ResultFalse()
    {
        //Arrange
        MyId id;
        MyEntity<MyId>? entity1, entity2;

        //Act
        id = new(10);
        entity1 = new(id, 1);
        entity2 = null;

        //Assert
        Assert.IsFalse(entity1 == entity2);
    }

    [Test]
    public void BothNull_EqualOperator_ResultTrue()
    {
        //Arrange
        MyId id;
        MyEntity<MyId>? entity1, entity2;

        //Act
        id = new(10);
        entity1 = null;
        entity2 = null;

        //Assert
        Assert.IsTrue(entity1 == entity2);
    }

    [Test]
    public void FirstNull_NotEqualOperator_ResultTrue()
    {
        //Arrange
        MyId id;
        MyEntity<MyId>? entity1, entity2;

        //Act
        id = new(10);
        entity1 = null;
        entity2 = new(id, 1);

        //Assert
        Assert.IsTrue(entity1 != entity2);
    }

    [Test]
    public void SecondNull_NotEqualOperator_ResultTrue()
    {
        //Arrange
        MyId id;
        MyEntity<MyId>? entity1, entity2;

        //Act
        id = new(10);
        entity1 = new(id, 1);
        entity2 = null;

        //Assert
        Assert.IsTrue(entity1 != entity2);
    }

    [Test]
    public void BothNull_NotEqualOperator_ResultFalse()
    {
        //Arrange
        MyId id;
        MyEntity<MyId>? entity1, entity2;

        //Act
        id = new(10);
        entity1 = null;
        entity2 = null;

        //Assert
        Assert.IsFalse(entity1 != entity2);
    }
}