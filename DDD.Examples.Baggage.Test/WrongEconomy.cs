
namespace DDD.Examples.Baggage.Test;

public class WrongEconomy
{
    [Test]
    public void NoAllowanceSpecified()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder();

        MyBaggage = B
            .AddAccessory(new BaggageSize(10, 10, 10), 5, "Laptop")
            .Build(nameof(MyBaggage));

        Assert.IsTrue(B.Collector.HasErrors);
    }

    [Test]
    public void CheckedBaggageExceeds1ItemAndHandExceeds1Item()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder();

        MyBaggage = B
            .SetAllowance(new EconomyBaggageAllowance())
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Bag")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Black suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Red suitcase")
            .Build(nameof(MyBaggage));

        Assert.IsTrue(B.Collector.ErrorsCount == 2);
    }

    [Test]
    public void CheckedBaggageExceeds1ItemCabinExceedsWeight()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder();

        MyBaggage = B
            .SetAllowance(new EconomyBaggageAllowance())
            .AddAccessory(new BaggageSize(30, 20, 10), 15, "Laptop")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Bag")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Black suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Red suitcase")
            .Build(nameof(MyBaggage));

        Assert.IsTrue(B.Collector.ErrorsCount == 2);
    }
}
