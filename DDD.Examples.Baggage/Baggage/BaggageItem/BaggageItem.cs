using DDD.Foundations;

namespace DDD.Examples.Baggage;

public abstract record class BaggageItem(BaggageSize Size, decimal Weight) : ValueObject
{
    private record class LocalValidator(NotificationCollector Collector) : InvariantValidator(Collector)
    {
        public bool IsAllowedSize(BaggageItem baggageItem)
        {
            var valid = baggageItem.IsAllowedSize();
            if (!valid)
                AddError(InvariantErrorCode.AboveMaximum, $"Baggage size exceeds allowed dimensions.");
            return valid;
        }
    }

    public abstract bool IsAllowedSize();

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var validator = new LocalValidator(collector);
        return validator.IsAllowedSize(this);
    }
}
