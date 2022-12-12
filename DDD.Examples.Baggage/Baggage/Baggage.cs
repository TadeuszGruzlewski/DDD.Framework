using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class Baggage : ValueObject
{
    public IBaggageAllowance? Allowance { get; internal set; }
    private readonly List<BaggageItem> baggage = new();

    internal Baggage() { }

    public void AddBaggageItem(BaggageItem bagaggeItem) => baggage.Add(bagaggeItem);

    public List<BaggageItem> Accessories => baggage.Where(b => b.GetType() == typeof(Accessory)).ToList();
    public List<BaggageItem> HandBaggage => baggage.Where(b => b.GetType() == typeof(HandBaggage)).ToList();
    public List<BaggageItem> CabinBaggage => baggage.Where(b => b.GetType() == typeof(Accessory) | b.GetType() == typeof(HandBaggage)).ToList();
    public List<BaggageItem> CheckedBaggage => baggage.Where(b => b.GetType() == typeof(CheckedBaggage)).ToList();

    public override bool AssertInvariants(List<InvariantError> errors)
    {
        var result = true;

        var invariant = new Invariant(errors);
        invariant.IsNotNullReference(Allowance, nameof(Allowance));
        if (Allowance is not null)
            result &= Allowance.IsBaggageAllowed(this, errors);

        foreach (var item in baggage)
            result &= item.AssertInvariants(errors);

        return result;
    }
}
