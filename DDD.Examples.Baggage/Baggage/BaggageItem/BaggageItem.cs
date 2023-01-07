using DDD.Foundations;

namespace DDD.Examples.Baggage;

public abstract record class BaggageItem(BaggageSize Size, decimal Weight, string Name, BaggageAllowance Allowance) : ValueObject(Name);
