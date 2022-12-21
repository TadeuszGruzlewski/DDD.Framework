using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class Baggage : ValueObject
{
    public BaggageAllowance? Allowance { get; internal set; }
    private readonly List<BaggageItem> baggage = new();

    internal Baggage() { }

    public void AddBaggageItem(BaggageItem bagaggeItem) => baggage.Add(bagaggeItem);

    public List<BaggageItem> Accessories => baggage.Where(b => b.GetType() == typeof(Accessory)).ToList();
    public List<BaggageItem> HandBaggage => baggage.Where(b => b.GetType() == typeof(HandBaggage)).ToList();
    public List<BaggageItem> CabinBaggage => baggage.Where(b => b.GetType() == typeof(Accessory) | b.GetType() == typeof(HandBaggage)).ToList();
    public List<BaggageItem> CheckedBaggage => baggage.Where(b => b.GetType() == typeof(CheckedBaggage)).ToList();


    protected override bool LocalValidate(NotificationCollector collector)
    {
        var result = true;

        foreach (var item in baggage)
            result &= item.Validate(collector, nameof(item));

        var validator = new InvariantValidator(collector);
        validator.IsNotNullReference(Allowance, nameof(Allowance));
        if (Allowance is not null)
            result &= BaggageAllowanceValidator.IsBaggageAllowed(collector, this, Allowance);

        return result;
    }
}
