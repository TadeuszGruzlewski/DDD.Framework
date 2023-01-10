using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class Baggage : ValueObject
{
    // Internal construct so Baggage can be created by the BaggageBuilder only
    internal Baggage() { }

    private CabinBaggage? CabinBaggage;
    private CheckedBaggage? CheckedBaggage;

    internal void SetAllowance(BaggageAllowance allowance)
    {
        if (allowance is null)
            throw new ArgumentNullException(nameof(allowance));
        CabinBaggage = new(allowance);
        CheckedBaggage = new(allowance);
    }

    public void AddAccessory(BaggageSize size, Weight weight, string description) =>
        CabinBaggage!.AddAccessory(size, weight, description);
    public void AddHandBaggage(BaggageSize size, Weight weight, string description) =>
        CabinBaggage!.AddHandBaggage(size, weight, description);
    public void AddCheckedBaggage(BaggageSize size, Weight weight, string description) =>
        CheckedBaggage!.AddCheckedBaggage(size, weight, description);

    protected override bool LocalValidate(NotificationCollector collector) =>
        CabinBaggage!.Validate(collector, "Cabin baggage") &
        CheckedBaggage!.Validate(collector, "Checked baggage");
}
