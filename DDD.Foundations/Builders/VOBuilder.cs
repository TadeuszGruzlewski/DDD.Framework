
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO valueObject;

    public NotificationCollector NotificationCollector { get; } = new();

    public VOBuilder(string valueObjectName) =>
        valueObject = Create(valueObjectName);

    protected abstract VO Create(string valueObjectName);

    //valueObject = Create(valueObjectName).Invoke();

    //protected abstract Func<VO> Create(string valueObjectName);

    public VO? Build()
    {
        valueObject.Validate(NotificationCollector, valueObject.Name!);
        return NotificationCollector.HasErrors ? null : valueObject;
    }
}
