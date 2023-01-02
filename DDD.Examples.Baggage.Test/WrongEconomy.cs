
namespace DDD.Examples.Baggage.Test;

public class WrongEconomy
{
    [Test]
    public void NoAllowanceSpecified()
    {
        var B = new BaggageBuilder();

        B.Build("Baggage");

        Assert.That(B.NotificationCollector.HasErrors);
    }

    [Test]
    public void CheckedBaggageExceeds1ItemAndHandExceeds1Item()
    {
        var B = new BaggageBuilder();

        B.SetAllowance(new EconomyBaggageAllowance())
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Bag")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Black suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Red suitcase")
            .Build("Baggage");

        Assert.That(B.NotificationCollector.ErrorsCount == 2);
    }

    [Test]
    public void CheckedBaggageExceeds1ItemCabinExceedsWeight()
    {
        var B = new BaggageBuilder();

        B.SetAllowance(new EconomyBaggageAllowance())
            .AddAccessory(new BaggageSize(30, 20, 10), 15, "Laptop")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Bag")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Black suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Red suitcase")
            .Build("Baggage");

        Assert.That(B.NotificationCollector.ErrorsCount == 2);
    }
}
