using System.Reflection;

namespace DDD.Foundations;

public abstract class VOBuilder<TValueObject> : IVOBuilder<TValueObject> where TValueObject : ValueObject
{
    protected TValueObject Root;

    public NotificationCollector NotificationCollector { get; } = new();

    public VOBuilder(string rootName)
    {
        const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
        var constructor = typeof(TValueObject).GetConstructor(flags, new[] { typeof(string) });
        if (constructor is null)
            throw new Exception(
                $"{typeof(TValueObject)} must implement an internal constructor with the parameter 'string rootName', calling base(rootName).");
        Root = (TValueObject)constructor.Invoke(new object[] { rootName });
    }

    public TValueObject? Build()
    {
        Root.Validate(NotificationCollector);
        return NotificationCollector.HasErrors ? null : Root;
    }
}
