using DDD.Primitives.Finance;
using NUnit.Framework;
using System;

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

    [Test]
    public void PriceTestOK()
    {
        var p = new Price(Currency.USD, 10);

        Assert.AreEqual(p.Amount, 10);
    }

    [Test]
    public void PriceTestFailure()
    {
        Assert.Throws<ArgumentException>(() => new Price(Currency.USD, 0));
    }

}
