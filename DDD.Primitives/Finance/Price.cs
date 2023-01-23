namespace DDD.Primitives.Finance;

public record class Price(Currency Currency, decimal Amount) : Money(Currency, Amount)
{
    public override bool IsValid()
    {
        bool valid = Amount > 0;
        if (!valid)
            SetErrorMsg($"{GetType().Name}.Amount must be a positive number.");
        return valid;
    }
}
