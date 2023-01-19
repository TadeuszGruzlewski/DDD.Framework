
namespace DDD.Examples.Baggage.Test;

public class WrongBussines
{
    [Test]
    public void NoAllowanceSpecified()
    {
        Assert.Throws<ArgumentNullException>(() => new BaggageBuilder(null, ""));
    }

    [Test]
    public void AccessoryExceedsSizeAndWeight()
    {
        var B = new BaggageBuilder(new BusinessBaggageAllowance(), "Baggage");

        B.AddAccessory(new BaggageSize(10, 10, 100), new Weight(50), "Laptop")
            .Build();

        Assert.That(B.NotificationCollector.ErrorsCount == 2);
    }

    [Test]
    public void AccessoryExceeds1Item()
    {
        var B = new BaggageBuilder(new BusinessBaggageAllowance(), "Baggage");

        B.AddAccessory(new BaggageSize(10, 10, 10), new Weight(5), "Laptop")
            .AddAccessory(new BaggageSize(10, 10, 10), new Weight(5), "Camera")
            .Build();

        Assert.That(B.NotificationCollector.HasErrors);
    }

    [Test]
    public void HandBaggageExceeds2Items()
    {
        var B = new BaggageBuilder(new BusinessBaggageAllowance(), "Baggage");

        B.AddHandBaggage(new BaggageSize(30, 20, 10), new Weight(5), "Small suitcase")
            .AddHandBaggage(new BaggageSize(30, 20, 10), new Weight(5), "Bag")
            .AddHandBaggage(new BaggageSize(30, 20, 10), new Weight(5), "Another bag")
            .Build();

        Assert.That(B.NotificationCollector.HasErrors);
    }

    [Test]
    public void CheckedBaggageExceedsSizeAndWeight()
    {
        var B = new BaggageBuilder(new BusinessBaggageAllowance(), "Baggage");

        B.AddCheckedBaggage(new BaggageSize(10, 100, 100), new Weight(50), "Suitcase")
            .Build();

        Assert.That(B.NotificationCollector.ErrorsCount == 2);
    }

    [Test]
    public void CheckedBaggageExceeds2Items()
    {
        var B = new BaggageBuilder(new BusinessBaggageAllowance(), "Baggage");

        B.AddCheckedBaggage(new BaggageSize(10, 10, 10), new Weight(5), "Small suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), new Weight(5), "Big suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), new Weight(5), "Another suitcase")
            .Build();

        Assert.That(B.NotificationCollector.HasErrors);
    }

    [Test]
    public void AllPossibleErrors()
    {
        var B = new BaggageBuilder(new BusinessBaggageAllowance(), "Baggage");

        B.AddAccessory(new BaggageSize(80, 10, 10), new Weight(50), "Laptop")
            .AddAccessory(new BaggageSize(80, 10, 10), new Weight(50), "Camera")
            .AddHandBaggage(new BaggageSize(30, 20, 100), new Weight(50), "Small suitcase")
            .AddHandBaggage(new BaggageSize(30, 20, 100), new Weight(50), "Bag")
            .AddHandBaggage(new BaggageSize(30, 20, 100), new Weight(50), "Another bag")
            .AddCheckedBaggage(new BaggageSize(100, 100, 10), new Weight(50), "Small suitcase")
            .AddCheckedBaggage(new BaggageSize(100, 100, 10), new Weight(50), "Big suitcase")
            .AddCheckedBaggage(new BaggageSize(100, 100, 10), new Weight(50), "Another suitcase")
            .Build();

        Assert.That(B.NotificationCollector.HasErrors);
    }

}
