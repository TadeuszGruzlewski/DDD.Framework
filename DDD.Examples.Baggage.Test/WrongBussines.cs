
namespace DDD.Examples.Baggage.Test;

public class WrongBussines
{
    [Test]
    public void NoAllowanceSpecified()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder<Baggage>(nameof(MyBaggage));

        MyBaggage = B
            .AddAccessory(new BaggageSize(10, 10, 10), 5, "Laptop")
            .Build();

        Assert.IsTrue(B.Collector.HasErrors);
    }

    [Test]
    public void AccessoryExceedsSizeAndWeight()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder<Baggage>(nameof(MyBaggage));

        MyBaggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddAccessory(new BaggageSize(10, 10, 100), 50, "Laptop")
            .Build();

        Assert.IsTrue(B.Collector.ErrorsCount == 2);
    }

    [Test]
    public void AccessoryExceeds1Item()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder<Baggage>(nameof(MyBaggage));

        MyBaggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddAccessory(new BaggageSize(10, 10, 10), 5, "Laptop")
            .AddAccessory(new BaggageSize(10, 10, 10), 5, "Camera")
            .Build();

        Assert.IsTrue(B.Collector.HasErrors);
    }

    [Test]
    public void HandBaggageExceeds2Items()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder<Baggage>(nameof(MyBaggage));

        MyBaggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Small suitcase")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Bag")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Another bag")
            .Build();

        Assert.IsTrue(B.Collector.HasErrors);
    }

    [Test]
    public void CheckedBaggageExceedsSizeAndWeight()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder<Baggage>(nameof(MyBaggage));

        MyBaggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddCheckedBaggage(new BaggageSize(10, 100, 100), 50, "Suitcase")
            .Build();

        Assert.IsTrue(B.Collector.ErrorsCount == 2);
    }

    [Test]
    public void CheckedBaggageExceeds2Items()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder<Baggage>(nameof(MyBaggage));

        MyBaggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Small suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Big suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Another suitcase")
            .Build();

        Assert.IsTrue(B.Collector.HasErrors);
    }

}
