using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class Baggage : ValueObject
{
    // Internal construct so Baggage can be created by the BaggageBuilder only
    internal Baggage() { }

    public CabinBaggage? CabinBaggage { get; private set; }
    public CheckedBaggage? CheckedBaggage { get; private set; }

    internal void SetAllowance(BaggageAllowance allowance)
    {
        if (allowance is null)
            throw new ArgumentNullException(nameof(allowance));
        CabinBaggage = new(allowance);
        CheckedBaggage = new(allowance);
    }

    internal void AddAccessory(BaggageSize size, Weight weight, string description) =>
        CabinBaggage!.AddAccessory(size, weight, description);
    internal void AddHandBaggage(BaggageSize size, Weight weight, string description) =>
        CabinBaggage!.AddHandBaggage(size, weight, description);
    internal void AddCheckedBaggage(BaggageSize size, Weight weight, string description) =>
        CheckedBaggage!.AddCheckedBaggage(size, weight, description);

    protected override bool LocalValidate(NotificationCollector collector) =>
        CabinBaggage!.Validate(collector, "Cabin baggage") &
        CheckedBaggage!.Validate(collector, "Checked baggage");
}
