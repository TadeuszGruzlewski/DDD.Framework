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
                AddError(InvariantErrorCode.AboveMaximum, fieldName, $"Number of baggage items exceeds the allowed limit of {allowedNumber} items.");
            return valid;
        }
    }

    private Baggage() { }

    private readonly CabinBaggageList cabinBaggageList = new();

    private readonly CheckedBaggageList checkedBaggageList = new();

    private BaggageAllowance? allowance;

    public IReadOnlyCollection<BaggageItem> Accessories => CabinBaggage.Where(b => b.GetType() == typeof(Accessory)).ToList();
    public IReadOnlyCollection<BaggageItem> HandBaggage => CabinBaggage.Where(b => b.GetType() == typeof(HandBaggage)).ToList();
    public IReadOnlyCollection<BaggageItem> CabinBaggage => cabinBaggageList.BaggageItems;
    public IReadOnlyCollection<BaggageItem> CheckedBaggage => checkedBaggageList.BaggageItems;

    public void SetAllowance(BaggageAllowance allowance)
    {
        this.allowance = allowance;
        cabinBaggageList.Allowance = allowance;
        checkedBaggageList.Allowance = allowance;
    }

    public void AddAccessory(BaggageSize size, decimal weight, string description)
    {
        Accessory accessory = new(size, weight, description);
        cabinBaggageList.AddBaggageItem(accessory);
    }

    public void AddHandBaggage(BaggageSize size, decimal weight, string description)
    {
        HandBaggage handBaggage = new(size, weight, description);
        cabinBaggageList.AddBaggageItem(handBaggage);
    }

    public void AddCheckedBaggage(BaggageSize size, decimal weight, string description)
    {
        CheckedBaggage checkedBaggage = new(size, weight, description);
        checkedBaggageList.AddBaggageItem(checkedBaggage);
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        // Programmatic error
        var validator = new LocalValidator(collector);
        validator.IsNotNullReference(allowance, nameof(allowance));
        if (allowance is null)
            return false;

        // Domain invariants
        // Baggage scope - number of items
        var valid =
            validator.IsAllowedNumber(Accessories, allowance.NumberOfAccessories, "Accessories") &
            validator.IsAllowedNumber(HandBaggage, allowance.NumberOfHandBaggages, "Hand baggage") &
            validator.IsAllowedNumber(CheckedBaggage, allowance.NumberOfCheckedBaggages, "Checked baggage");

        // Cabin and Checked baggage subscopes
        return valid & 
            cabinBaggageList.Validate(collector, "Cabin baggage") &        
            checkedBaggageList.Validate(collector, "Checked baggage");       
    }
}
