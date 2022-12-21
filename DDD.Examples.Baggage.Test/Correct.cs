
namespace DDD.Examples.Baggage.Test;

public class Correct
{
    [Test]
    public void Economy()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder();

        MyBaggage = B
            .SetAllowance(new EconomyBaggageAllowance())
            .AddAccessory(new BaggageSize(10, 10, 10), 5, "Laptop")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Bag")
            .AddCheckedBaggage(new BaggageSize(50, 30, 30), 20, "Suitcase")
            .Build(nameof(MyBaggage));

        Assert.That(MyBaggage, Is.Not.Null);
    }

    [Test]
    public void Business()
    {
        Baggage? MyBaggage;             
        var B = new BaggageBuilder();

        MyBaggage = B
            .AddAccessory(new BaggageSize(10, 10, 10), 5, "Laptop")
            .AddHandBaggage(new BaggageSize(30, 20, 10), 5, "Bag")
            .AddHandBaggage(new BaggageSize(50, 20, 15), 7, "Small suitcase")
            .AddCheckedBaggage(new BaggageSize(50, 30, 30), 20, "Black suitcase")
            .AddCheckedBaggage(new BaggageSize(50, 40, 20), 30, "Red suitcase")
            .SetAllowance(new BusinessBaggageAllowance())
            .Build(nameof(MyBaggage));

        Assert.That(MyBaggage, Is.Not.Null);
    }
}
