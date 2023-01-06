using DDD.Foundations;

namespace DDD.Examples.Baggage;

abstract public record class BaggageList : ValueObject
{
    public BaggageAllowance? Allowance { get; internal set; }

    public IReadOnlyCollection<BaggageItem> BaggageItems => baggageItems;
    protected readonly List<BaggageItem> baggageItems = new();

    public int NumberOfItems => baggageItems.Count;

    public void AddBaggageItem(BaggageItem bagaggeItem) => baggageItems.Add(bagaggeItem);

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var result = true;

        foreach (var item in BaggageItems)
            result &= item.Validate(collector, item.Name!);

        return result;
    }
}
