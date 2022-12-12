using DDD.Primitives.Finance;
using NUnit.Framework;

namespace CurrencyTests;

public class BasicTests
{
    [Test]
    public void USD()
    {
        //Assert
        Assert.AreEqual(Currency.USD.NumericCode, 840);
        Assert.AreEqual(Currency.USD.AlphaCode, "USD");
        Assert.AreEqual(Currency.USD.Symbol, "$");
        Assert.AreEqual(Currency.USD.Entity, "United States dollar");
        Assert.AreEqual(Currency.USD.Name, "United States dollar");
    }

}
