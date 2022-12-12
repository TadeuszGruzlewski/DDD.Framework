using System.Diagnostics;
using DDD.Foundations;
using DDD.Primitives.UoMs;

namespace DDD.Primitives.Quantities;

public abstract record class Quantity : Primitive
{
    public UoM? UoM { get; init; }
    public decimal Amount { get; init; }

    protected static new Quantity? Create(Type type, params object[] args) =>
        (Quantity?)Primitive.Create(type, args);

    public override bool IsValid()
    {
        bool valid = Amount >= 0;
        if (!valid)
            ErrorMsg = $"{GetType().Name}.Amount must not be negative.";
        return valid;
    }

    protected abstract bool IsNone();
    public bool IsZero => IsNone();
    public bool IsAlmostZero(decimal epsilon = 0) => Amount <= epsilon;

    public bool IsCompatibleWith(Quantity? q) => UoM!.IsCompatibleWith(q?.UoM!);
    public static void TestCompatibility(Quantity? q1, Quantity? q2)
    {
        Debug.Assert(!AnyIsNull(q1, q2));
        q1.UoM!.TestCompatibilityTo(q2.UoM!);
    }

    public Quantity Normalize() => Create(GetType(), UoM!.Base, Amount * UoM!.Rate)!;
    public Quantity ConvertTo(UoM newUoM) => Create(GetType(), newUoM, Amount * UoM!.GetRateTo(newUoM))!;
    public decimal GetRateTo(Quantity q) => Amount / q.Amount * UoM!.GetRateTo(q.UoM!);

    protected static bool IsNull(Quantity? q) => q is null;
    protected static bool AnyIsNull(Quantity? q1, Quantity? q2) => q1 is null || q2 is null;

    public static Quantity? operator *(decimal d, Quantity? q) => q * d;
    public static Quantity? operator *(Quantity? q, decimal d) =>
        IsNull(q) ? null : Create(q.GetType(), q.UoM!, q.Amount * d)!;
    public static Quantity? operator /(Quantity? q, decimal d) =>
        IsNull(q) ? null : Create(q.GetType(), q.UoM!, q.Amount / d)!;
    public static decimal? operator /(Quantity? q1, Quantity? q2)
    {
        if (AnyIsNull(q1, q2)) return null;
        TestCompatibility(q1, q2);
        return q1.GetRateTo(q2);
    }

    public static bool? operator <(Quantity? q1, Quantity? q2) => Less(q1, q2, false);
    public static bool? operator >(Quantity? q1, Quantity? q2) => Less(q2, q1, false);
    public static bool? operator <=(Quantity? q1, Quantity? q2) => Less(q1, q2, true);
    public static bool? operator >=(Quantity? q1, Quantity? q2) => Less(q2, q1, true);
    private static bool? Less(Quantity? q1, Quantity? q2, bool orEq)
    {
        if (AnyIsNull(q1, q2)) return null;
        TestCompatibility(q1, q2);
        if (q1.IsZero) return orEq ? 0 <= q2.Amount : 0 < q2.Amount;
        if (q2.IsZero) return orEq ? q1.Amount <= 0 : q1.Amount < 0;
        return orEq ? 1 <= q1.GetRateTo(q2) : 1 < q1.GetRateTo(q2); // TODO epsilon!
    }

    public static Quantity? operator +(Quantity? q1, Quantity? q2) => Add(q1, q2, +1);
    public static Quantity? operator -(Quantity? q1, Quantity? q2) => Add(q1, q2, -1);
    private static Quantity? Add(Quantity? q1, Quantity? q2, int sign)
    {
        if (AnyIsNull(q1, q2)) return null;
        TestCompatibility(q1, q2);
        if (q1.IsZero) return q2;
        if (q2.IsZero) return q1;
        return Create(q1.GetType(), q1.UoM!, q1.Amount * (1 + sign * q2.GetRateTo(q1)))!;
//        return q1 with { UoM = q1.UoM, Amount = q1.Amount * (1 + sign * q2.GetRateTo(q1)) }; // for performance benchmark
    }  
}
