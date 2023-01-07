﻿
using DDD.Foundations;

namespace DDD.Examples.Baggage;

public record class AccessoryItem(BaggageSize Size, decimal Weight, string Description, BaggageAllowance Allowance) : BaggageItem(Size, Weight, Description, Allowance)
{
    private record class Validator(NotificationCollector Collector, BaggageAllowance Allowance) : InvariantValidator(Collector)
    {
        public bool IsAllowedSize(BaggageItem baggageItem)
        {
            var valid = baggageItem.Size <= Allowance.AccessoryItemSize;
            if (!valid)
                AddError($"Size exceeds allowed {Allowance.AccessoryItemSize}.");
            return valid;
        }
    }

    protected override bool LocalValidate(NotificationCollector collector)
    {
        var validator = new Validator(collector, Allowance);
        return validator.IsAllowedSize(this);
    }
}