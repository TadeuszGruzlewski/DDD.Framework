using DDD.Foundations;

namespace DDD.Examples.Baggage;

internal record class CheckedBaggage(BaggageAllowance Allowance) : ValueObject
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedNumber(decimal numberOfItems)
        {
            var allowedNumber = Allowance.NumberOfCheckedBaggages; 
            var valid = numberOfItems <= allowedNumber;
            if (!valid)
                AddError($"Number of checked items exceeds the allowed limit of {allowedNumber}.");
            return valid;
        }
    }

    public IReadOnlyCollection<CheckedItem> BaggageItems => baggageItems;
    protected readonly List<CheckedItem> baggageItems = new();

    public int NumberOfItems => baggageItems.Count;

    public void AddCheckedBaggage(BaggageSize size, decimal weight, string description)
    {
        CheckedItem checkedItem = new(size, weight, description, Allowance);
        baggageItems.Add(checkedItem);
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
