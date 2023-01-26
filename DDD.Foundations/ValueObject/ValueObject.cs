
namespace DDD.Foundations;

public abstract record class ValueObject(string? Name = default)
{
    public bool? IsValid { get; private set; }

    protected abstract bool LocalValidate(NotificationCollector collector);

    public bool Validate(NotificationCollector collector)
    {
        // validated already? - circuit breaker
        if (IsValid is null)
        {
            collector.EnterEmbeddedScope(Name);
            IsValid = LocalValidate(collector);
            collector.ExitEmbeddedScope();
        }
        return (bool)IsValid;
    }
}
