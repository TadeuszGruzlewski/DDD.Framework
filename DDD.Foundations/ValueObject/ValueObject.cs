
namespace DDD.Foundations;

public abstract record class ValueObject(string? Name = default)
{
    public bool IsValidated { get; private set; } = false;
    public bool? IsValid { get; private set; } = null;

    protected abstract bool LocalValidate(NotificationCollector collector);

    public bool Validate(NotificationCollector collector, string objectName)
    {
        if (!IsValidated)
        {
            collector.ExtendContext(objectName);
            IsValid = LocalValidate(collector);
            collector.ReduceContext();
            IsValidated = true;
        }
        return (bool)IsValid!;
    }
}
