
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO? valueObject;

    public VOBuilder() =>
        valueObject = (VO?)Activator.CreateInstance(typeof(VO), true);

    public NotificationCollector NotificationCollector { get; private set; }

    public VO? Build(string objectName)
    {
        NotificationCollector = new(objectName);
        valueObject?.Validate(NotificationCollector, objectName);
        return NotificationCollector.HasErrors ? null : valueObject;
    }
}
