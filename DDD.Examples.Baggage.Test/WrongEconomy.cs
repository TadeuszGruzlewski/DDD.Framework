
namespace DDD.Examples.Baggage.Test;

public class WrongEconomy
{
    [Test]
    public void Economy()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .SetAllowance(new EconomyBaggageAllowance())
            .AddAccessory(new BaggageSize(10, 10, 10), 5)
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5)
            .AddCheckedBaggage(new BaggageSize(50, 30, 30), 20)
            .Build();

        Assert.That(baggage, Is.Not.Null);
    }

    [Test]
    public void Business()
    {
        var B = new BaggageBuilder<Baggage>();

        var baggage = B
            .AddAccessory(new BaggageSize(10, 10, 10), 5)
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5)
            .AddHandBaggage(new BaggageSize(50, 20, 15), 7)
            .AddCheckedBaggage(new BaggageSize(50, 30, 30), 20)
            .AddCheckedBaggage(new BaggageSize(50, 40, 20), 30)
            .SetAllowance(new BusinessBaggageAllowance())
            .Build();

        Assert.That(baggage, Is.Not.Null);
    }
}

