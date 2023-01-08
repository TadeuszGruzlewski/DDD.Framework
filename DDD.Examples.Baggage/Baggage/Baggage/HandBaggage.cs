using DDD.Foundations;

namespace DDD.Examples.Baggage;

internal record class HandBaggage(BaggageAllowance Allowance) : ValueObject
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedNumber(decimal numberOfItems)
        {
            var allowedNumber = Allowance.NumberOfCheckedBaggages;
            var valid = numberOfItems <= allowedNumber;
            if (!valid)
                AddError($"Number of {numberOfItems} checked items exceeds the allowed limit of {allowedNumber}.");
            return valid;
        }
    }

    public IReadOnlyCollection<HandItem> BaggageItems => baggageItems;
    protected readonly List<HandItem> baggageItems = new();

    public decimal Weight => baggageItems.Sum(i => i.Weight);

    public int NumberOfItems => baggageItems.Count;

    public void AddHandBaggage(BaggageSize size, decimal weight, string description)
    {
        HandItem handItem = new(size, weight, description, Allowance);
        baggageItems.Add(handItem);
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
