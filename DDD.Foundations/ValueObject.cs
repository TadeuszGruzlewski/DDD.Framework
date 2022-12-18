
namespace DDD.Foundations;

public abstract record class ValueObject
{
    public bool IsValidated { get; private set; } = false;
    public bool? IsValid { get; private set; } = null;

    protected abstract bool LocalValidate(NotificationCollector collector);

    public bool Validate(NotificationCollector collector)
    {
        if (!IsValidated)
        {
            IsValid = LocalValidate(collector);
            IsValidated = true;
        }
        return (bool)IsValid!;
    }
}
