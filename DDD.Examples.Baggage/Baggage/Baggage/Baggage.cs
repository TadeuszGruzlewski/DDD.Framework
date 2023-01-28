using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class Baggage : ValueObject
{
    // Internal constructor: Baggage can be created by the BaggageBuilder only
    internal Baggage(string rootName) : base(rootName) { }

    public CabinBaggage? CabinBaggage { get; private set; }
    public CheckedBaggage? CheckedBaggage { get; private set; }

    internal void SetAllowance(BaggageAllowance allowance)
    {
        if (allowance is null)
            throw new ArgumentNullException(nameof(allowance));
        CabinBaggage = new(allowance, "Cabin baggage");
        CheckedBaggage = new(allowance, "Checked baggage");
    }

    internal void AddAccessory(Size size, Weight weight, string name) =>
        CabinBaggage!.AddAccessory(size, weight, name);
    internal void AddHandBaggage(Size size, Weight weight, string name) =>
        CabinBaggage!.AddHandBaggage(size, weight, name);
    internal void AddCheckedBaggage(Size size, Weight weight, string name) =>
        CheckedBaggage!.AddCheckedBaggage(size, weight, name);

    protected override bool LocalValidate(NotificationCollector collector) =>
        CabinBaggage!.Validate(collector) &
        CheckedBaggage!.Validate(collector);
}
