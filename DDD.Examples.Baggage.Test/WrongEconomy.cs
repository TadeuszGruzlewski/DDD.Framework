
namespace DDD.Examples.Baggage.Test;

public class WrongEconomy
{
    [Test]
    public void NoAllowanceSpecified()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .AddAccessory(new BaggageSize(10, 10, 10), 5)
            .Build();

        Assert.IsTrue(B.Collector.HasErrors);
    }

    [Test]
    public void CheckedBaggageExceeds1ItemAndHandExceeds1Item()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .SetAllowance(new EconomyBaggageAllowance())
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5)
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5)
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5)
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5)
            .Build();

        Assert.IsTrue(B.Collector.ErrorsCount == 2);
    }

    [Test]
    public void CheckedBaggageExceeds1ItemCabinExceedsWeight()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .SetAllowance(new EconomyBaggageAllowance())
            .AddAccessory(new BaggageSize(30, 20, 10), 15)
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5)
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5)
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5)
            .Build();

        Assert.IsTrue(B.Collector.ErrorsCount == 2);
    }
}
