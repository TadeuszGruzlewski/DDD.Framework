using DDD.Foundations;

namespace DDD.Examples.Baggage;

internal record class Accessories(BaggageAllowance Allowance) : ValueObject
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedNumber(decimal numberOfItems)
        {
            var allowedNumber = Allowance.NumberOfAccessories;
            var valid = numberOfItems <= allowedNumber;
            if (!valid)
                AddError($"Number of {numberOfItems} items exceeds the allowed limit of {allowedNumber}.");
            return valid;
        }
    }

    public IReadOnlyCollection<AccessoryItem> BaggageItems => baggageItems;
    protected readonly List<AccessoryItem> baggageItems = new();

    public decimal Weight => baggageItems.Sum(i => i.Weight);

    public int NumberOfItems => baggageItems.Count;

    public void AddAccessory(BaggageSize size, decimal weight, string description)
    {
        AccessoryItem accessoryItem = new(size, weight, description, Allowance);
        baggageItems.Add(accessoryItem);
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var validator = new Validator(collector, Allowance);
        var valid = validator.IsAllowedNumber(NumberOfItems);
        foreach (var item in baggageItems)
            valid &= item.Validate(collector, item.Name!);
        return valid;
    }
}
