
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO? valueObject;

    public VOBuilder() =>
        valueObject = (VO?)Activator.CreateInstance(typeof(VO), true);

    public NotificationCollector NotificationCollector { get; } = new();

    public VO? Build(string objectName)
    {
        valueObject?.Validate(NotificationCollector, objectName);
        return NotificationCollector.HasErrors ? null : valueObject;
    }
}
