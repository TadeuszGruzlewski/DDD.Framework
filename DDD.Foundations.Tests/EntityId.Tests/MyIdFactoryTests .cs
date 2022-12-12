using NUnit.Framework;

namespace EntityIdFactoryTests;

public class FactoryMethodTests
{
    [Test]
    public void CreateGoodByFactoryMethod_CheckIfCorrectExampleId()
    {
        //Arrange
        (MyId? id, string? errorMsg) result;

        //Act
        result = MyId.Create(MyIdType.Id1, 1500);

        //Assert
        Assert.IsTrue(result.errorMsg is null);
        Assert.IsTrue(result.id is not null);
        Assert.AreEqual(1500, result.id!.Code);
    }

    [Test]
    public void CreateWrongByFactoryMethod_CheckIfNull()
    {
        //Arrange
        (MyId? id, string? errorMsg) result;

        //Act
        result = MyId.Create(MyIdType.Id1, 0);

        //Assert
        Assert.IsTrue(result.id is null);
        Assert.IsTrue(result.errorMsg is not null);
    }
}

public class FactoryClassTests
{
    [Test]
    public void CreateGoodByFactoryClass_CheckIfCorrect()
    {
        //Arrange
        MyId id;

        //Act
        id = MyIdFactory.Create(MyIdType.Id1, 1500);

        //Assert
        Assert.IsTrue(id is MyId1);
        Assert.AreEqual(1500, id.Code);
    }

    [Test]
    public void CreateWrongByFactoryClass_CheckIfEntityNullId()
    {
        //Arrange
        MyId id;

        //Act
        id = MyIdFactory.Create(MyIdType.Id1, 0);

        //Assert
        Assert.IsTrue(id is NullMyId);
    }
}
