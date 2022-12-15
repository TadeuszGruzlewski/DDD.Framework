
namespace DDD.Examples.Baggage.Test;

public class WrongEconomy
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
}
