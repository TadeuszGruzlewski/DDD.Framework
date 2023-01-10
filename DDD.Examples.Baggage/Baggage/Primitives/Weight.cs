﻿using DDD.Foundations;
using DDD.Primitives.Dimensions;
using DDD.Primitives.Measures;

namespace DDD.Examples.Baggage;

// Unit of Measure by default in kg
// Should be extended to allow UoM either kg or pound
public record class Weight(decimal Value) : Primitive
{
    public static bool operator <=(Weight w1, Weight w2) => w1.Value <= w2.Value;
    public static bool operator >=(Weight w1, Weight w2) => !(w1 <= w2);

    public static Weight operator +(Weight w1, Weight w2) => new(w1.Value + w2.Value);

    public override bool IsValid()
    {
        bool valid = 0 <= Value;
        if (!valid)
            ErrorMsg = $"{GetType()}.Value must not be negative.";
        return valid;
    }
}
