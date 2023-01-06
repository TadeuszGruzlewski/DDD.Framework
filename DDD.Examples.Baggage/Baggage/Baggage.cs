using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class Baggage : ValueObject
{
    protected record class LocalValidator(NotificationCollector Collector) : InvariantValidator(Collector)
    {
        public bool IsAllowedNumber(IReadOnlyCollection<BaggageItem> baggageItems, int allowedNumber, string fieldName)
        {
            var valid = baggageItems.Count <= allowedNumber;
            if (!valid)
                AddError($"Number of {fieldName} exceeds the allowed limit of {allowedNumber} items.");
            return valid;
        }
    }

    private Baggage() { }

    private readonly CabinBaggageList CabinBaggageList = new();

    private readonly CheckedBaggageList CheckedBaggageList = new();

    private BaggageAllowance? Allowance;

    public IReadOnlyCollection<BaggageItem> Accessories => CabinBaggageList.Accessories;
    public IReadOnlyCollection<BaggageItem> HandBaggage => CabinBaggageList.HandBaggage;
    public IReadOnlyCollection<BaggageItem> CabinBaggage => CabinBaggageList.BaggageItems;
    public IReadOnlyCollection<BaggageItem> CheckedBaggage => CheckedBaggageList.BaggageItems;

    public void SetAllowance(BaggageAllowance allowance)
    {
        Allowance = allowance;
        CabinBaggageList.Allowance = allowance;
        CheckedBaggageList.Allowance = allowance;
    }

    public void AddAccessory(BaggageSize size, decimal weight, string description)
    {
        Accessory accessory = new(size, weight, description);
        CabinBaggageList.AddBaggageItem(accessory);
    }

    public void AddHandBaggage(BaggageSize size, decimal weight, string description)
    {
        HandBaggage handBaggage = new(size, weight, description);
        CabinBaggageList.AddBaggageItem(handBaggage);
    }

    public void AddCheckedBaggage(BaggageSize size, decimal weight, string description)
    {
        CheckedBaggage checkedBaggage = new(size, weight, description);
        CheckedBaggageList.AddBaggageItem(checkedBaggage);
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        // Programmatic error
        var validator = new LocalValidator(collector);
        validator.IsNotNullReference(Allowance, nameof(Allowance));
        if (Allowance is null)
            return false;

        // Domain invariants
        // Baggage scope - number of items
        var valid =
            validator.IsAllowedNumber(Accessories, Allowance.NumberOfAccessories, "accessories") &
            validator.IsAllowedNumber(HandBaggage, Allowance.NumberOfHandBaggages, "hand baggage") &
            validator.IsAllowedNumber(CheckedBaggage, Allowance.NumberOfCheckedBaggages, "checked baggage");

        // Cabin and Checked baggage subscopes
        return valid & 
            CabinBaggageList.Validate(collector, "Cabin baggage") &        
            CheckedBaggageList.Validate(collector, "Checked baggage");       
    }
}
