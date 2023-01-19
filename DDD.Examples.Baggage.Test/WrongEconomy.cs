
namespace DDD.Examples.Baggage.Test;

public class WrongEconomy
{
    [Test]
    public void CheckedBaggageExceeds1ItemAndHandExceeds1Item()
    {
        var B = new BaggageBuilder(new EconomyBaggageAllowance(), "Baggage");

        B.AddHandBaggage(new BaggageSize(30, 20, 10), new Weight(5), "Bag")
            .AddHandBaggage(new BaggageSize(30, 20, 10), new Weight(5), "Suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), new Weight(5), "Black suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), new Weight(5), "Red suitcase")
            .Build();

        Assert.That(B.NotificationCollector.ErrorsCount == 2);
    }

    [Test]
    public void CheckedBaggageExceeds1ItemCabinExceedsWeight()
    {
        var B = new BaggageBuilder(new EconomyBaggageAllowance(), "Baggage");

        B.AddAccessory(new BaggageSize(30, 20, 10), new Weight(15), "Laptop")
            .AddHandBaggage(new BaggageSize(30, 20, 10), new Weight(5), "Bag")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), new Weight(5), "Black suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), new Weight(5), "Red suitcase")
            .Build();

        Assert.That(B.NotificationCollector.ErrorsCount == 2);
    }
}
