
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO? ValueObject;

    public VOBuilder() =>
        ValueObject = (VO?)Activator.CreateInstance(typeof(VO), true);

    public readonly NotificationCollector Collector = new();

    public VO? Build(string objectName)
    {
        ValueObject?.Validate(Collector, objectName);
        return Collector.HasErrors ? null : ValueObject;
    }
}
