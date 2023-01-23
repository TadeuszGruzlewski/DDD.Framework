using DDD.Foundations;

namespace DDD.Examples.Baggage;

public abstract record class BaggageItem(Size Size, Weight Weight, string Name, BaggageAllowance Allowance) : ValueObject(Name);
