
namespace DDD.Foundations;

public abstract record class ValueObject
{
    public bool IsValidated { get; private set; } = false;
    public bool? IsValid { get; private set; } = null;

    protected abstract bool LocalValidate(NotificationCollector collector, string objectName);

    public bool Validate(NotificationCollector collector, string objectName)
    {
        if (!IsValidated)
        {
            IsValid = LocalValidate(collector, objectName);
            IsValidated = true;
        }
        return (bool)IsValid!;
    }
}
