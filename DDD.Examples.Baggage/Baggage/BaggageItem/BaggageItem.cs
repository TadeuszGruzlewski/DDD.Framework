using DDD.Foundations;

namespace DDD.Examples.Baggage;

public abstract record class BaggageItem(BaggageSize Size, decimal Weight, string Description) : ValueObject
{
    private record class LocalValidator(NotificationCollector Collector) : InvariantValidator(Collector)
    {
        public bool IsAllowedSize(BaggageItem baggageItem, string fieldName)
        {
            var valid = baggageItem.IsAllowedSize();
            if (!valid)
                AddError(InvariantErrorCode.AboveMaximum, $"Baggage size exceeds allowed dimensions.", fieldName);
            return valid;
        }
    }

    public abstract bool IsAllowedSize();

    protected override bool LocalValidate(NotificationCollector collector, string objectName)
    {
        var validator = new LocalValidator(collector);
        return validator.IsAllowedSize(this, objectName);
    }
}
