
namespace DDD.Examples.Baggage.Test;

public class WrongBussines
{
    [Test]
    public void NoAllowanceSpecified()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .AddAccessory(new BaggageSize(10, 10, 10), 5)
            .Build();

        Assert.IsTrue(B.Errors.Any());
    }

    [Test]
    public void AccessoryExceedsSizeAndWeight()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddAccessory(new BaggageSize(10, 10, 100), 50)
            .Build();

        Assert.IsTrue(B.Errors.Count == 2);
    }

    [Test]
    public void AccessoryExceeds1Item()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddAccessory(new BaggageSize(10, 10, 10), 5)
            .AddAccessory(new BaggageSize(10, 10, 10), 5)
            .Build();

        Assert.IsTrue(B.Errors.Any());
    }

    [Test]
    public void HandBaggageExceeds2Items()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5)
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5)
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5)
            .Build();

        Assert.IsTrue(B.Errors.Any());
    }

    [Test]
    public void CheckedBaggageExceedsSizeAndWeight()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddCheckedBaggage(new BaggageSize(10, 100, 100), 50)
            .Build();

        Assert.IsTrue(B.Errors.Count == 2);
    }

    [Test]
    public void CheckedBaggageExceeds2Items()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .SetAllowance(new BusinessBaggageAllowance())
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5)
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5)
            .AddCheckedBaggage(new BaggageSize(10, 10, 10), 5)
            .Build();

        Assert.IsTrue(B.Errors.Any());
    }

}
