
namespace DDD.Examples.Baggage.Test;

public class Correct
{
    [Test]
    public void Economy()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder(new EconomyBaggageAllowance(), "My baggage");

        MyBaggage = B
            .AddAccessory(new Size(10, 10, 10), new Weight(5), "Laptop")
            .AddHandBaggage(new Size(30, 20, 10), new Weight(5), "Bag")
            .AddCheckedBaggage(new Size(50, 30, 30), new Weight(20), "Suitcase")
            .Build();

        Assert.That(MyBaggage, Is.Not.Null);
    }

    [Test]
    public void Business()
    {
        Baggage? MyBaggage;
        var B = new BaggageBuilder(new BusinessBaggageAllowance(), "My baggage");

        MyBaggage = B
            .AddAccessory(new Size(10, 10, 10), new Weight(5), "Laptop")
            .AddHandBaggage(new Size(30, 20, 10), new Weight(5), "Bag")
            .AddHandBaggage(new Size(50, 20, 15), new Weight(7), "Small suitcase")
            .AddCheckedBaggage(new Size(50, 30, 30), new Weight(20), "Black suitcase")
            .AddCheckedBaggage(new Size(50, 40, 20), new Weight(30), "Red suitcase")
            .Build();

        Assert.That(MyBaggage, Is.Not.Null);
    }
}
