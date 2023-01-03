
namespace DDD.Examples.Baggage.Test;

public class WrongBussines
{
    [Test]
    public void NoAllowanceSpecified()
    {
        var B = new BaggageBuilder();

        B.Build("Baggage");

        Assert.That(B.NotificationCollector.HasErrors);
    }

    [Test]
    public void AccessoryExceedsSizeAndWeight()
    {
        var B = new BaggageBuilder();

        B.SetAllowance(new BusinessBaggageAllowance())
            .AddAccessory(new BaggageSize(10, 10, 100), 50, "Laptop")
            .Build("Baggage");

        Assert.That(B.NotificationCollector.ErrorsCount == 2);
    }

    [Test]
    public void AccessoryExceeds1Item()
    {
        var B = new BaggageBuilder();

         B.SetAllowance(new BusinessBaggageAllowance())
            .AddAccessory(new BaggageSize(10, 10, 10), 5, "Laptop")
            .AddAccessory(new BaggageSize(10, 10, 10), 5, "Camera")
            .Build("Baggage");

        Assert.That(B.NotificationCollector.HasErrors);
    }

    [Test]
    public void HandBaggageExceeds2Items()
    {
        var B = new BaggageBuilder();

        B.SetAllowance(new BusinessBaggageAllowance())
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Small suitcase")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Bag")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Another bag")
            .Build("Baggage");

        Assert.That(B.NotificationCollector.HasErrors);
    }

    [Test]
    public void CheckedBaggageExceedsSizeAndWeight()
    {
        var B = new BaggageBuilder();

        B.SetAllowance(new BusinessBaggageAllowance())
            .AddCheckedBaggage(new BaggageSize(10, 100, 100), 50, "Suitcase")
            .Build("Baggage");

        Assert.That(B.NotificationCollector.ErrorsCount == 2);
    }

    [Test]
    public void CheckedBaggageExceeds2Items()
    {
        var B = new BaggageBuilder();

        B.SetAllowance(new BusinessBaggageAllowance())
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Small suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Big suitcase")
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5, "Another suitcase")
            .Build("Baggage");

        Assert.That(B.NotificationCollector.HasErrors);
    }

    [Test]
    public void ManyErrors()
    {
        var B = new BaggageBuilder();

        B.SetAllowance(new BusinessBaggageAllowance())
            .AddAccessory(new BaggageSize(80, 10, 10), 50, "Laptop")
            .AddAccessory(new BaggageSize(80, 10, 10), 50, "Camera")
            .AddHandBaggage(new BaggageSize(30, 20, 100), 50, "Small suitcase")
            .AddHandBaggage(new BaggageSize(30, 20, 100), 50, "Bag")
            .AddHandBaggage(new BaggageSize(30, 20, 100), 50, "Another bag")
            .AddCheckedBaggage(new BaggageSize(100, 100, 10), 50, "Small suitcase")
            .AddCheckedBaggage(new BaggageSize(100, 100, 10), 50, "Big suitcase")
            .AddCheckedBaggage(new BaggageSize(100, 100, 10), 50, "Another suitcase")
            .Build("Baggage");

        Assert.That(B.NotificationCollector.HasErrors);
    }

}
