using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class HandBaggage(BaggageAllowance Allowance, string Name) : ValueObject(Name)
{
    protected record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedNumber(decimal numberOfItems)
        {
            var allowedNumber = Allowance.NumberOfCheckedItems;
            var valid = numberOfItems <= allowedNumber;
            if (!valid)
                AddError($"Number of {numberOfItems} hand items exceeds the allowed limit of {allowedNumber}.");
            return valid;
        }
    }

    public IReadOnlyCollection<HandItem> BaggageItems => baggageItems;
    protected readonly List<HandItem> baggageItems = new();

    public Weight Weight => new(baggageItems.Sum(i => i.Weight.Value));

    public int NumberOfItems => baggageItems.Count;

    public void AddHandBaggage(Size size, Weight weight, string name)
    {
        HandItem handItem = new(size, weight, name, Allowance);
        baggageItems.Add(handItem);
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var validator = new Validator(collector, Allowance);
        var valid = validator.IsAllowedNumber(NumberOfItems);
        foreach (var item in baggageItems)
            valid &= item.Validate(collector);
        return valid;
    }
}
