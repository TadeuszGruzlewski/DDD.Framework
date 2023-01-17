
namespace DDD.Foundations;

public abstract record class ValueObject(string? Name = default)
{
    public string Name { get; protected set; } = "";

    public bool IsValidated { get; private set; } = false;
    public bool? IsValid { get; private set; } = null;

    protected abstract bool LocalValidate(NotificationCollector collector);

    public bool Validate(NotificationCollector collector, string scopeName)
    {
        // circuit breaker
        if (!IsValidated)
        {
            collector.EnterEmbeddedScope(scopeName);
            IsValid = LocalValidate(collector);
            collector.ExitEmbeddedScope();
            IsValidated = true;
        }
        return (bool)IsValid!;
    }
}
