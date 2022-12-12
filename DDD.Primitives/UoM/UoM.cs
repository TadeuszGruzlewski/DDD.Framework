using DDD.Foundations;

namespace DDD.Primitives.UoMs;

public abstract record class UoM(int Code, string Name, decimal Rate) : Enumeration(Code, Name)
{
    public UoM Base => GetBase();
    protected abstract UoM GetBase();

    public bool IsCompatibleWith(UoM? u) => GetType() == u?.GetType();

    public void TestCompatibilityTo(UoM? u)
    {
        if (!IsCompatibleWith(u))
            throw new ArgumentException($"Incompatible Units of Measure: {GetType()} and {u?.GetType()}.");
    }

    public decimal GetRateTo(UoM u)
    {
        TestCompatibilityTo(u);
        return Rate / u.Rate;
    }
}
