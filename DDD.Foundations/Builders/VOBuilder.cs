
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO valueObject;

    public NotificationCollector NotificationCollector { get; } = new();

    public VOBuilder(string valueObjectName) =>
        valueObject = Create(valueObjectName);

    protected abstract VO Create(string valueObjectName);

    public VO? Build()
    {
        valueObject.Validate(NotificationCollector);
        return NotificationCollector.HasErrors ? null : valueObject;
    }
}
