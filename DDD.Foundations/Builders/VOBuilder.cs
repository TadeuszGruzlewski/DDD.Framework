
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO? valueObject;

    public VOBuilder() =>
        valueObject = (VO?)Activator.CreateInstance(typeof(VO), true);

    public readonly NotificationCollector Collector = new();

    public VO? Build(string objectName)
    {
        valueObject?.Validate(Collector, objectName);
        return Collector.HasErrors ? null : valueObject;
    }
}
