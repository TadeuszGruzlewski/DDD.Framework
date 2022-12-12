using System;
using DDD.Foundations;

namespace EntityIdFactoryTests;

public enum MyIdType
{
    Id1,    // code range (1001, 2000)
    Id2,    // code range (2001, 3000)
    // etc
}

public abstract record class MyId(long Code) : EntityId
{
    public static (MyId?, string?) Create(MyIdType idType, long code)
    {
        try
        {
            MyId? id = idType switch
            {
                MyIdType.Id1 => new MyId1(code),
                MyIdType.Id2 => new MyId2(code),
                _ => throw new NotImplementedException()
            };
            return (id, null);
        }
        catch (Exception ex)
        {
            return (null, ex.Message);
        }
    }
}

public record class NullMyId() : MyId(0)
{
    public override bool IsValid() => true;
}

public record class MyId1(long Code) : MyId(Code)
{
    public override bool IsValid()
    {
        // example validation
        var valid = (1000 < Code) & (Code <= 2000);
        if (!valid)
            ErrorMsg = $"{GetType().Name}.Code must be in the range of (1001, 2000)";
        return valid;
    }
}

public record class MyId2(long Code) : MyId(Code)
{
    public override bool IsValid()
    {
        // example validation
        var valid = (2000 < Code) & (Code <= 3000);
        if (!valid)
            ErrorMsg = $"{GetType().Name}.Code must be in the range of (2001, 3000)";
        return valid;
    }
}

public static class MyIdFactory
{
    public static MyId Create(MyIdType idType, long code)
    {
        try
        {
            return
                idType switch
                {
                    MyIdType.Id1 => new MyId1(code),
                    MyIdType.Id2 => new MyId2(code),
                    _ => throw new NotImplementedException()
                };
        }
        catch (Exception ex)
        {
            return new NullMyId() { ErrorMsg = ex.Message };
        }
    }
}
