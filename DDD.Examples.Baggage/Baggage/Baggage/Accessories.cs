using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class Accessories(BaggageAllowance Allowance, string Name) : ValueObject(Name)
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

    public Weight Weight => new(baggageItems.Sum(i => i.Weight.Value));

    public int NumberOfItems => baggageItems.Count;

    public void AddAccessory(BaggageSize size, Weight weight, string name)
    {
        AccessoryItem accessoryItem = new(size, weight, name, Allowance);
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
